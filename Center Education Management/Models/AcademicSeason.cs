using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class AcademicSeason
    {
        public int Id { get; set; } 
        public int CenterId { get; set; } 
        public string? Name { get; set; }
        public AcademicSeasonType Type { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public AcademicSeasonStatus Status { get; set; }
        public bool IsCurrent { get; set; }
        public virtual Center? Center { get; set; } 
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
