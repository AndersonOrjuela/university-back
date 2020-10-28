using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.BL.Models
{

    [Table("OfficeAssignment", Schema = "dbo")]
    public class OfficeAssignment
    {
       [Key]
       [ForeignKey("Instructor")]

        public int InstructorID { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }

    }
}
