using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public enum Grade
    {
        A, B, C, D, E

    }
    public class EnrollmentDTO
    {

        [Required(ErrorMessage = "El Campo EnrollmentID  Es Requerido")]
        public int EnrollmentID { get; set; }

        [Required(ErrorMessage = "El Campo CourseID  Es Requerido")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "El Campo StudentID  Es Requerido")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "El Campo Grade  Es Requerido")]
        public Grade Grade { get; set; }

        //Navegabilidad 

        public CourseDTO Course { get; set; }

        public StudentDTO Student { get; set; }
    }
}
