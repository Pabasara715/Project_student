using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SRS_System
{
    public class User
    {
        [Key]
        public int UserId { get; set; } 
        public string fName { get; set; }   
        public string UserName { get; set; }
        public string Password { get; set; }
        public string lName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
