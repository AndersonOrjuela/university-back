using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace University.BL.DTOs
{
    public class CourseInstructorDTO
    {


        [Required(ErrorMessage = "El Campo ID  Es Requerido")]
        public int ID { get; set; }

        [Required(ErrorMessage = "El Campo CourseID  Es Requerido")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "El Campo IntructorID  Es Requerido")]
        public int InstructorID { get; set; }

        public CourseDTO Course { get; set; }

        public InstructorDTO InstructorDTO { get; set; }

    }
}
