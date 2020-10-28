//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace University.Web.Controllers
//{
//    public class DepartmentsController : ApiController
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
    public class DepartmentsController : ApiController
    {
        private IMapper mapper;
        private readonly DepartmentService departmentService = new DepartmentService(new DepartamentRepository(UniversityContext.Create()));
        public DepartmentsController()
        {

            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();

        }

        /// <summary>
        /// obtiene los objetos Departments
        /// </summary>
        /// <returns>Listado de los obejtos de Depatment</returns>
        /// <response code="200">ok.Devuelve el listado de objetos solicitado.</response>

        [HttpGet]
        [ResponseType(typeof(IEnumerable<DepartamentDTO>))]
        public async Task<IHttpActionResult> Get()
        {

            var departments = await departmentService.GetAll();
            var departamentDTO = departments.Select(x => mapper.Map<DepartamentDTO>(x));

            return Ok(departamentDTO); //status code 200
        }
        /// <summary>
        /// Obtiene un objeto Department por su Id.
        /// </summary>
        /// <param name="id">Id del objeto Department </param>
        /// <returns>Obejto Department</returns>
        /// <response code="200">ok.Devuelve el objeto  solicitado.</response>
        

        [HttpGet]
        [ResponseType(typeof(DepartamentDTO))]
        public async Task<IHttpActionResult> Get(int id)
        {

            var department = await departmentService.GetById(id);
            var departamentDTO = mapper.Map<DepartamentDTO>(department);

            return Ok(departamentDTO); //status code 200
        }


        /// <summary>
        /// Inserta Un Objeto Department Con Id.
        /// </summary>
        /// <param name="departamentDTO">Nombre del Department</param>
        /// <returns>Objeto Course Insertado</returns>
        /// <response code="400">BadRequest. solicitud incorrecta .</response>
        /// <response code="200">ok. inserta el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpPost]
        public async Task<IHttpActionResult> Post(DepartamentDTO departamentDTO)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);// status code 400


            try
            {
                var department = mapper.Map<Department>(departamentDTO);

                department = await departmentService.Insert(department);
                return Ok(departamentDTO); //status code 200
                
            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500
            }

        }

        /// <summary>
        /// Consulta Department por Id.
        /// </summary>
        /// <param name="departamentDTO"> Nombre del Department</param>
        /// <param name="id">Id del Department </param>
        /// <returns>Objeto Course Solicitado. </returns>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado .</response>
        /// <response code="200">ok. el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>

        [HttpPut]
        public async Task<IHttpActionResult> Put(DepartamentDTO departamentDTO, int id)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            if (departamentDTO.DepartmentID != id)
                return BadRequest();

            var flag = await departmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404

            try
            {
                var department = mapper.Map<Department>(departamentDTO);

               department = await departmentService.Update(department);
                return Ok(departamentDTO); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500
            }

        }

        /// <summary>
        /// Elimina un objeto Department.
        /// </summary>
        /// <param name="id">Id del Department a eliminar. </param>
        /// <returns>Objeto Department eliminado</returns>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado .</response>
        /// <response code="200">ok.elimino el objeto solicitado</response>
        /// <response code="500">Internal server error .error interno del servidor.</response>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            var flag = await departmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status 404

            try
            {

                await departmentService.Delete(id);
                return Ok(); //status code 200

            }
            catch (Exception ex)
            {

                return InternalServerError(ex); //Status code 500
            }

        }

    }
}
