using Center_Education_Management.Model;
using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Center_Education_Management.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MaxCapacity { get; set; }
        public decimal Price { get; set; }
        public string? ScheduleJson { get; set; }
        public GroupStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject? Subject { get; set; }
        public int SeasonId { get; set; }
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public int ClassroomId { get; set; }
        public virtual Classroom? Classroom { get; set; }
        public int StageId { get; set; }
        public virtual EducationalStage? Stage { get; set; }
        public virtual AcademicSeason? AcademicSeason { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Content> Contents { get; set; }
            = new List<Content>();

    }
}
