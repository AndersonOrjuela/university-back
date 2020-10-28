using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Data;

namespace University.BL.Repositories.Implements
{
    public class CourseInstructorRepository : GenericRepository<CourseInstructor>, ICourseInstructorRepository

    {



        public CourseInstructorRepository(UniversityContext universityContext) : base(universityContext)

        {



        }

    }
}
