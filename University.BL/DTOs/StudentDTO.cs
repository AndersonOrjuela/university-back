using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class StudentDTO
    {
        [Required(ErrorMessage = "El Campo ID Es Requerido")]
        public int ID { get; set; }

        [Required(ErrorMessage = "El Campo LastName Es Requerido")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El Campo FirstMidName Es Requerido")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "El Campo EnrollmentDate Es Requerido")]
        public DateTime EnrollmentDate { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1}", LastName, FirstMidName); }

        }
    }
}
