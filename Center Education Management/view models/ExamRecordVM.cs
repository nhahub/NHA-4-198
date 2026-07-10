using Center_Education_Management.Enums;
using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class ExamQuestionVM
    {
        public int AnswerId { get; set; } 
        public int OrderIndex { get; set; }
        public string? Body { get; set; } 
        public string? Type { get; set; }
        public string? Options { get; set; }
        public int Points { get; set; }
        public string? AnswerText { get; set; }
        public string? SavedAt { get; set; }
    }
    public class ExamQuestionReadVM
    {
        public int Id { get; set; }
        public int OrderIndex { get; set; }
        public string? Body { get; set; }
        public string? Options { get; set; }
        public string? CorrectAnswer { get; set; }
        public decimal Points { get; set; }
    }
    public class SaveAnswerVM
    {
        public int AnswerId { get; set; } 
        public string? AnswerText { get; set; } 
    }

    public class SubmitExamVM
    {
        public int ExamId { get; set; } 
        public List<SaveAnswerVM>? Answers { get; set; } 
    }

    public class ManualGradeVM
    {
        public int AnswerId { get; set; }
        public int EarnedPoints { get; set; }
        public string? GradedByAssistant { get; set; }
        public string? Grade
        {
            get; set;
        }

        public class ExamResultVM
        {
            public int ExamId { get; set; }
            public int StudentId { get; set; }
            public string? StudentName { get; set; }
            public decimal? Score { get; set; }
            public int TotalPoints { get; set; }
            public double Percentage { get; set; }
            public string? AttemptStatus { get; set; }
            public string? SubmittedAt { get; set; }
        }

        public class ExamAnalyticsVM
        {
            public int ExamId { get; set; }
            public string? Title { get; set; }
            public int TotalStudents { get; set; }
            public int Submitted { get; set; }
            public double AverageScore { get; set; }
            public double HighestScore { get; set; }
            public double LowestScore { get; set; }
            public double PassRate { get; set; }
            public int TotalAttempts { get; set; }

        }
    }
}
