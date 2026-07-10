using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public bool IsActive { get; set; }
        public int StageId { get; set; }
        public virtual EducationalStage? Stage { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
            = new List<Teacher>();
        public virtual ICollection<Group> Groups { get; set; }
            = new List<Group>();
        public virtual ICollection<QuestionBank> Questions { get; set; }
            = new List<QuestionBank>();
        public virtual ICollection<Exam> Exams { get; set; }
            = new List<Exam>();
        public virtual ICollection<Assignment> Assignments { get; set; }
            = new List<Assignment>();
        public virtual ICollection<StudentLead> Leads { get; set; } = new List<StudentLead>();
    }
}
