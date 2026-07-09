using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class Parent : User
    {
        public Permission Permissions { get; set; }
        public virtual ICollection<Student> Students { get; set; }
            = new List<Student>();
    }
}
