using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS_System
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? fName { get; set; }
        public string? lName { get; set; }
        public int GPA { get; set; }


    }
}
