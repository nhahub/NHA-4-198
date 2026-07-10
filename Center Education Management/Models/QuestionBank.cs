using Center_Education_Management.Enums;
using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class QuestionBank
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject? Subject { get; set; }
        public string? Lesson { get; set; } 
        public QuestionType Type { get; set; }
        public string? Body { get; set; }
        public string? OptionsJson { get; set; }
        public string? CorrectAnswer { get; set; }
        public decimal Points { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; } 
            = new List<ExamQuestion>();
        public virtual ICollection<ExamAttempt> ExamAttempts { get; set; }
             = new List<ExamAttempt>();
    }
}
