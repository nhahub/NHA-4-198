using Center_Education_Management.Enums;
using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class Classroom
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public ClassroomType Type { get; set; } 
        public bool IsVirtual { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
