using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public EnrollmentStatus Status { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Group? Group { get; set; }
    }
}
