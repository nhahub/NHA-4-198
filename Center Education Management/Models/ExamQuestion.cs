using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class ExamQuestion
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public virtual Exam? Exam { get; set; }
        public int QuestionBankId { get; set; }
        public virtual QuestionBank? QuestionBank { get; set; }
        public string? BodySnapshot { get; set; }
        public string? OptionsSnapshot { get; set; }
        public string? CorrectAnswer { get; set; }
        public QuestionType Type { get; set; }
        public decimal Points { get; set; }
        public int OrderIndex { get; set; }
    }
}
