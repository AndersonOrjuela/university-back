using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()

        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>(); // GET
                cfg.CreateMap<CourseDTO, Course>(); // POST-PUT

                cfg.CreateMap<Student, StudentDTO>(); // GET
                cfg.CreateMap<StudentDTO, Student>(); // POST-PUT

                cfg.CreateMap<Enrollment, EnrollmentDTO>(); // GET
                cfg.CreateMap<EnrollmentDTO, Enrollment>(); // POST-PUT

                cfg.CreateMap<Department, DepartamentDTO>(); // GET
                cfg.CreateMap<DepartamentDTO, Department>(); // POST-PUT

                cfg.CreateMap<OfficeAssignment, OfficeAssignmentDTO>(); // GET
                cfg.CreateMap<OfficeAssignmentDTO, OfficeAssignment>(); // POST-PUT

                cfg.CreateMap<Instructor, InstructorDTO>(); // GET
                cfg.CreateMap<InstructorDTO, Instructor>(); // POST-PUT



            });

        }
    }
}
