using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class QuestionBankCreateVM
    {
        public int TeacherId { get; set; }
        public int CenterId { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Lesson { get; set; } = string.Empty;
        public QuestionType Type { get; set; }
        public string Body { get; set; } = string.Empty;
        public string? OptionsJson { get; set; }
        public string? CorrectAnswer { get; set; }
        public decimal Points { get; set; }

    }

    public class QuestionBankUpdateVM
    {
        public string? Subject { get; set; }
        public string? Lesson { get; set; }
        public QuestionType Type { get; set; }
        public string? Body { get; set; }
        public string? OptionsJson { get; set; }
        public string? CorrectAnswer { get; set; }
        public decimal Points { get; set; }

    }

    public class QuestionBankReadVM
    {
        public int Id { get; set; }
        public string? TeacherName { get; set; }
        public string? CenterName { get; set; }
        public string? Subject { get; set; }
        public string? Lesson { get; set; }
        public string? Type { get; set; }
        public string? Body { get; set; }
        public string? Options { get; set; }
        public string? CorrectAnswer { get; set; }
        public decimal Points { get; set; }

    }
}
