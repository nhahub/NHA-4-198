using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class TeacherAssistant : User
    {
        public int TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public bool CanUpload { get; set; }
        public bool CanGrade { get; set; }
        public bool CanApproveRequests { get; set; }
        public DateTime JoinedAt { get; set; }
        public virtual ICollection<QRToken> QRTokens { get; set; } 
            = new List<QRToken> ();
        public virtual ICollection<Attendance> Attendance { get; set; } 
            = new List<Attendance> ();
        public virtual ICollection<Content> Content { get; set; } 
            = new List<Content> ();
    }
}
