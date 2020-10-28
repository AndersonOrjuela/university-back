using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class DepartamentDTO
    {

        
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "El Campo Name Es Requerido")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Campo BudGet  Es Requerido")]
        public double Budget { get; set; }

        
        public DateTime StartDate { get; set; }

       
        public int InstructorID { get; set; }


    }
}
