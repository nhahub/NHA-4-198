using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class Superadmin : User
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Center> centers { get; set; }
            = new List<Center>();
    }
}
