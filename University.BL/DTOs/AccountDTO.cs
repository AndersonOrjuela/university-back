using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class LogintDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password{ get; set; }
    }
}
