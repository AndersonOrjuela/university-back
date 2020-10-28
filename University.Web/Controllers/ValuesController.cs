using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.BL.Data;
using Newtonsoft.Json;
namespace University.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly UniversityContext universityContext = UniversityContext.Create();

        [HttpGet]
        public IHttpActionResult Get()
        {

            var courses = (from q in universityContext.Courses
                           select new
                           {
                               q.CourseID,
                               q.Title,
                               q.Credits

                           }).ToList();
            return Ok(JsonConvert.SerializeObject(courses));

        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var course = (from q in universityContext.Courses
                          where q.CourseID == id
                          select new
                          {
                              q.CourseID,
                              q.Title,
                              q.Credits
                          }).ToList();
            return Ok(JsonConvert.SerializeObject(course));
        }
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
