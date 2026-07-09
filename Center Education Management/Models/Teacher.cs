using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class Teacher : User
    {
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public virtual Subject? Subject { get; set; }
        public int SubjectId { get; set; }
        public string? Bio { get; set; }
        public DateTime JoinedAt { get; set; }
        public DateTime? LeftAt { get; set; }
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public virtual ICollection<TeacherAssistant> Assistants { get; set; } = new List<TeacherAssistant>();
        public virtual ICollection<QuestionBank> QuestionBanks { get; set; } = new List<QuestionBank>();
        public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public virtual ICollection<Content> Content { get; set; } = new List<Content>();
        public virtual ICollection<TeacherEducationalStage> TeacherStages { get; set; }
        = new List<TeacherEducationalStage>();
    }
}
