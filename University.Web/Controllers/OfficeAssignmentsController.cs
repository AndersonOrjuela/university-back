//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace University.Web.Controllers
//{
//    public class OfficeAssignmentsController : ApiController
//    {
//    }
//}
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
    public class OfficeAssignmentsController : ApiController
    {
        private IMapper mapper;
        private readonly OfficeAssignmentService officeAssignmentService = new OfficeAssignmentService(new OfficeAssignmentRepository(UniversityContext.Create()));
        public OfficeAssignmentsController()
        {

            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();

        }
        /// <summary>
        /// obtiene los objetos OfficeAssignment
        /// </summary>
        /// <returns>Listado de los obejtos de OfficeAssignment</returns>
        /// <response code="200">ok.Devuelve el listado de objetos solicitado.</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<OfficeAssignmentDTO>))]
        public async Task<IHttpActionResult> Get()
        {

            var officeAssignments = await officeAssignmentService.GetAll();
            var officeAssignmentDTO = officeAssignments.Select(x => mapper.Map<OfficeAssignmentDTO>(x));

            return Ok(officeAssignmentDTO); //status code 200
        }
        /// <summary>
        /// Obtiene un objeto OfficeAssignment por su Id.
        /// </summary>
        /// <param name="id">Id del objeto OfficeAssignment </param>
        /// <returns>Obejto OfficeAssignment</returns>
        /// <response code="200">ok.Devuelve el objeto  solicitado.</response>
        [HttpGet]
        [ResponseType(typeof(OfficeAssignmentDTO))]
        public async Task<IHttpActionResult> Get(int id)
        {

            var officeAssignment = await officeAssignmentService.GetById(id);
            var officeAssignmentDTO = mapper.Map<OfficeAssignmentDTO>(officeAssignment);

            return Ok(officeAssignmentDTO); //status code 200
        }
        /// <summary>
        /// Inserta Un Objeto OfficeAssignment Con Id.
        /// </summary>
        /// <param name="officeAssignmentDTO">Nombre del OfficeAssignment</param>
        /// <returns>Objeto OfficeAssignment Insertado</returns>
        /// <response code="400">BadRequest. solicitud incorrecta .</response>
        /// <response code="200">ok. inserta el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(OfficeAssignmentDTO officeAssignmentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var officeAssignment = mapper.Map<OfficeAssignment>(officeAssignmentDTO);

                officeAssignment = await officeAssignmentService.Insert(officeAssignment);
                return Ok(officeAssignmentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500
            }

        }
        /// <summary>
        /// Consulta OfficeAssignment por Id.
        /// </summary>
        /// <param name="officeAssignmentDTO"> Nombre del OfficeAssignment</param>
        /// <param name="id">Id del OfficeAssignment </param>
        /// <returns>Objeto OfficeAssignment Solicitado. </returns>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado .</response>
        /// <response code="200">ok. el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpPut]
        public async Task<IHttpActionResult> Put(OfficeAssignmentDTO officeAssignmentDTO, int id)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            if (officeAssignmentDTO.InstructorID != id)
                return BadRequest();

            var flag = await officeAssignmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404

            try
            {
                var officeAssignment = mapper.Map<OfficeAssignment>(officeAssignmentDTO);

                officeAssignment = await officeAssignmentService.Update(officeAssignment);
                return Ok(officeAssignmentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500
            }

        }
        /// <summary>
        /// Elimina un objeto OfficeAssignment.
        /// </summary>
        /// <param name="id">Id del OfficeAssignment a eliminar. </param>
        /// <returns>Objeto OfficeAssignment eliminado</returns>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado .</response>
        /// <response code="200">ok.elimino el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            var flag = await officeAssignmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404

            try
            {

                await officeAssignmentService.Delete(id);
                return Ok(); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500
            }

        }

    }
}