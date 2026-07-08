using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class ExamAttempt
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public virtual Exam? Exam { get; set; }
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public AttemptStatus Status { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public decimal TotalPoints { get; set; }
        public double Percentage { get; set; }
        public decimal? Score { get; set; }
        public int QuestionBankId { get; set; }
        public virtual QuestionBank? QuestionBank { get; set; }
        public virtual ICollection<ExamAnswer> Answers { get; set; } = new List<ExamAnswer>();
    }
}
