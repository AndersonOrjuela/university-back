using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.BL.Models;

namespace University.BL.Models
{

    [Table("Instructor", Schema = "dbo")]
    public class Instructor
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstMidName { get; set; }

        public DateTime HireDate { get; set; }

        //Foreing

        public virtual ICollection<Department> Departaments { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }

    }
}
