using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.Web.Controllers
{
    public class StudentsController : ApiController
    {
        private IMapper mapper;
        private readonly StudentService studentService = new StudentService(new StudentRepository(UniversityContext.Create()));
        public StudentsController()
        {

            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();

        }
        /// <summary>
        /// obtiene los objetos Students
        /// </summary>
        /// <returns>Listado de los obejtos de Student</returns>
        /// <response code="200">ok.Devuelve el listado de objetos solicitado.</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<StudentDTO>))]
        public async Task<IHttpActionResult> Get()
        {

            var students = await studentService.GetAll();
            var studentDTO = students.Select(x => mapper.Map<StudentDTO>(x));

            return Ok(studentDTO); //status code 200
        }
        /// <summary>
        /// Obtiene un objeto Student por su Id.
        /// </summary>
        /// <param name="id">Id del objeto Student </param>
        /// <returns>Obejto Student</returns>
        /// <response code="200">ok.Devuelve el objeto  solicitado.</response>
        [HttpGet]
        [ResponseType(typeof(StudentDTO))]
        public async Task<IHttpActionResult> Get(int id)
        {

            var student = await studentService.GetById(id);
            var studentDTO = mapper.Map<StudentDTO>(student);

            return Ok(studentDTO); //status code 200
        }
        /// <summary>
        /// Inserta Un Objeto Student Con Id.
        /// </summary>
        /// <param name="studentDTO">Nombre del Student</param>
        /// <returns>Objeto Student Insertado</returns>
        /// <response code="400">BadRequest. solicitud incorrecta .</response>
        /// <response code="200">ok. inserta el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                var student = mapper.Map<Student>(studentDTO);

               student = await studentService.Insert(student);
                return Ok(studentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500
            }

        }
        /// <summary>
        /// Consulta Student por Id.
        /// </summary>
        /// <param name="studentDTO"> Nombre del Student</param>
        /// <param name="id">Id del Student </param>
        /// <returns>Objeto Student Solicitado. </returns>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado .</response>
        /// <response code="200">ok. el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpPut]
        public async Task<IHttpActionResult> Put(StudentDTO studentDTO, int id)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            if (studentDTO.ID != id)
                return BadRequest();

            var flag = await studentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404

            try
            {
                var student = mapper.Map<Student>(studentDTO);

                student = await studentService.Update(student);
                return Ok(studentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500
            }

        }
        /// <summary>
        /// Elimina un objeto Student.
        /// </summary>
        /// <param name="id">Id del Student a eliminar. </param>
        /// <returns>Objeto Student eliminado</returns>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado .</response>
        /// <response code="200">ok.elimino el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            var flag = await studentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404

            try
            {

                await studentService.Delete(id);
                return Ok(); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500
            }

        }

    }
}