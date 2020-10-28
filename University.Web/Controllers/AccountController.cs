using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.BL.DTOs;

namespace University.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        /// <summary>
        /// Metodo encargado de realizar la autenticacion
        /// </summary>
        /// <param name="logintDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login(LogintDTO logintDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool isCredentialValid = (logintDTO.Password == "123456");
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(logintDTO.Username);
                return Ok(token);
            }else

            return Unauthorized();//status code 401

        }
    }
}
