using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;
using System;
using System.Web.Http.Description;
using System.Collections;
using System.Collections.Generic;

namespace University.Web.Controllers
{
    //[Authorize]
    [RoutePrefix("web/Courses")]
    public class CoursesController : ApiController
    {
        private IMapper mapper;

        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();

        }

        /// <summary>
        /// obtiene los objetos cursos
        /// </summary>
        /// <returns>Listado de los obejtos de cursos</returns>
        /// <response code="200">ok.Devuelve el listado de objetos solicitado.</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<CourseDTO>))]
        public async Task<IHttpActionResult> GetAll()

        {

            var courses = await courseService.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));

            return Ok(coursesDTO);// status code 200

        }
        /// <summary>
        /// Obtiene un objeto Course por su Id.
        /// </summary>
        /// <remarks>
        /// Aqui una descripcion mas larga si fuera necesario. Obtiene un objeto por su Id.
        /// </remarks>
        /// <param name="id">Id del objeto </param>
        /// <returns>Obejto Course</returns>
        /// <response code="200">ok.Devuelve el objeto  solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> GetById(int id)

        {

            var course = await courseService.GetById(id);
            if (course == null)
                return NotFound();

            var courseDTO = mapper.Map<CourseDTO>(course);

            return Ok(courseDTO);// status code 200

        }
        /// <summary>
        /// Inserta Un Objeto Course Con Id.
        /// </summary>
        /// <param name="courseDTO">Nombre del Curso</param>
        /// <returns>Objeto Course Insertado</returns>
        /// <response code="400">BadRequest. solicitud incorrecta .</response>
        /// <response code="200">ok. inserta el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>


        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // status code 400

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Insert(course);
                return Ok(courseDTO); //status code 200
            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //status code 500
            }

        }

        /// <summary>
        /// Consulta Course por Id.
        /// </summary>
        /// <param name="courseDTO"> Nombre del Course</param>
        /// <param name="id">Id del Course </param>
        /// <returns>Objeto Course Solicitado. </returns>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado .</response>
        /// <response code="200">ok. el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>

        [HttpPut]
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)//objet --> body / primitivo ---> url
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // status code 400

            if (courseDTO.CourseID != id)
                return BadRequest();
            var flag = await courseService.GetById(id);
            if (flag == null)
                return NotFound(); //status code 404

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Update(course);
                return Ok(courseDTO); //status code 200
            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //status code 500
            }

        }

        /// <summary>
        /// Elimina un objeto course.
        /// </summary>
        /// <param name="id">Id del curso a eliminar. </param>
        /// <returns>Objeto Course eliminado</returns>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado .</response>
        /// <response code="200">ok.elimino el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response> 

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            var flag = await courseService.GetById(id);
            if (flag == null)
                return NotFound(); //status code 404

            try
            {
                if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);
                else
                    throw new Exception("ForeignKeys");

                return Ok(); //status code 200
            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //status code 500
            }

        }


    }
}
