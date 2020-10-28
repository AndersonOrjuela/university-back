using System.Data.Entity;
using University.BL.Models;

namespace University.BL.Data
{
    public class UniversityContext : DbContext
    {
        private static UniversityContext universityContext = null;

        public UniversityContext() : base("UniversityContext")
        {




        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<OfficeAssignment> officeAssignments{ get; set; }
        public DbSet<Instructor> instructors { get; set; }




        public static UniversityContext Create()
        {
            if (universityContext == null)
                universityContext = new UniversityContext();

            return new UniversityContext();

        }


    }
}
//ATAJOS 
//ctrl + k + d formatear
//ctrol + k + c comentamos bloque
//ctrol + k + u desacomentariamos bloque
//ctrol + k + s rodeamos codigo 
//prop (double tab)
//ctrol + d 
//ctor (double tab) metodo constructor