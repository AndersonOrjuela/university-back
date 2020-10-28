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
    public class InstructorsController : ApiController
    {
        private IMapper mapper;
        private readonly InstructorService instructorService = new InstructorService(new InstructorRepository(UniversityContext.Create()));
        public InstructorsController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// obtiene los objetos Instructors
        /// </summary>
        /// <returns>Listado de los obejtos de Instructor</returns>
        /// <response code="200">ok.Devuelve el listado de objetos solicitado.</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<InstructorDTO>))]
        public async Task<IHttpActionResult> Get()
        {
            var instructors = await instructorService.GetAll();
            var instructorDTO = instructors.Select(x => mapper.Map<InstructorDTO>(x));
            return Ok(instructorDTO); //status code 200
        }
        /// <summary>
        /// Obtiene un objeto Instructor por su Id.
        /// </summary>
        /// <param name="id">Id del objeto Instructor </param>
        /// <returns>Obejto Instructor</returns>
        /// <response code="200">ok.Devuelve el objeto  solicitado.</response>
        [HttpGet]
        [ResponseType(typeof(InstructorDTO))]
        public async Task<IHttpActionResult> Get(int id)

        {
            var instructor = await instructorService.GetById(id);
            var instructorDTO = mapper.Map<InstructorDTO>(instructor);
            return Ok(instructorDTO); //status code 200

        }
        /// <summary>
        /// Inserta Un Objeto Instructor Con Id.
        /// </summary>
        /// <param name="instructorDTO">Nombre del Instructor</param>
        /// <returns>Objeto Instructor Insertado</returns>
        /// <response code="400">BadRequest. solicitud incorrecta .</response>
        /// <response code="200">ok. inserta el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpPost]

        public async Task<IHttpActionResult> Post(InstructorDTO instructorDTO)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try

            {
                var instructor = mapper.Map<Instructor>(instructorDTO);
                instructor = await instructorService.Insert(instructor);

             return Ok(instructorDTO); //status code 200

            }
            catch (Exception ex)

            {
                return InternalServerError(ex); //Status code 500

            }
        }
        /// <summary>
        /// Consulta Instructor por Id.
        /// </summary>
        /// <param name="instructorDTO"> Nombre del Instructor</param>
        /// <param name="id">Id del Instructor </param>
        /// <returns>Objeto Instructor Solicitado. </returns>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado .</response>
        /// <response code="200">ok. el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpPut]

        public async Task<IHttpActionResult> Put(InstructorDTO instructorDTO, int id)

        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (instructorDTO.ID != id)
               return BadRequest();

            var flag = await instructorService.GetById(id);
            if (flag == null)

               return NotFound(); // status 404
            try
            {
                var instructor = mapper.Map<Instructor>(instructorDTO);
                instructor = await instructorService.Update(instructor);

                return Ok(instructorDTO); //status code 200
            }
            catch (Exception ex)

            {
                return InternalServerError(ex); //Status code 500
            }

        }
        /// <summary>
        /// Elimina un objeto Instructor.
        /// </summary>
        /// <param name="id">Id del Instructor a eliminar. </param>
        /// <returns>Objeto Instructor eliminado</returns>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado .</response>
        /// <response code="200">ok.elimino el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpDelete]

        public async Task<IHttpActionResult> Delete(int id)

        {

            var flag = await instructorService.GetById(id);

            if (flag == null)

                return NotFound(); // status 404
            try

            {
                await instructorService.Delete(id);

                return Ok(); //status code 200

            }

            catch (Exception ex)

            {
                return InternalServerError(ex); //Status code 500

            }

        }





    }

}
