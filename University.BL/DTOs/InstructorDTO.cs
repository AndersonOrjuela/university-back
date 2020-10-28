using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using University.BL.Models;

namespace University.BL.DTOs
{
    public class InstructorDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El Campo LastName Es Requerido")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El Campo FirstMidName Es Requerido")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "El Campo HireDate  Es Requerido")]
        public DateTime HireDate { get; set; }
        //public virtual ICollection<Department> Departaments { get; set; }
        //public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }

        //public virtual OfficeAssignment OfficeAssignment { get; set; }

    }
}
