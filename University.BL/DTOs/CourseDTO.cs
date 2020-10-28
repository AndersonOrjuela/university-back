using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseDTO
    {
        [Required(ErrorMessage = "El Campo CourseID Es Requerido")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "El Campo Title Es Requerido")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "El Campo Credits Es Requerido")]
        public int Credits { get; set; }

    }
}
