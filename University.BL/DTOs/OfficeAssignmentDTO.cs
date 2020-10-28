using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace University.BL.DTOs
{
    public class OfficeAssignmentDTO
    {
        [Required(ErrorMessage = "El Campo IntructorID  Es Requerido")]
        public int InstructorID { get; set; }

        [Required(ErrorMessage = "El Campo Location  Es Requerido")]
        public string Location { get; set; }

        [Required(ErrorMessage = "El Campo Instructor  Es Requerido")]
        public InstructorDTO instructor { get; set; }

    }
}
