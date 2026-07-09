using Center_Education_Management.Enums;
using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class Session
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? VideoLink { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public virtual Group? Group { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual Classroom? Classroom { get; set; }
        public int ClassroomId { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public virtual ICollection<Content> Content { get; set; } = new List<Content>();
        public virtual ICollection<QRToken> QRToken { get; set; } = new List<QRToken>();
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public SessionStatus Status { get; set; }
    }
}
