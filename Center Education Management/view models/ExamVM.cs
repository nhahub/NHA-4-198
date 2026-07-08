using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class ExamVM
    {
        public int Id { get; set; } 
        public int TeacherId { get; set; } 
        public string? TeacherName { get; set; } 
        public string? GroupId { get; set; } 
        public string? GroupName { get; set; }
        public string? Title { get; set; } 
        public string? Subject { get; set; }
        public int DurationMinutes { get; set; }
        public int TotalPoints { get; set; }
        public bool ShuffleQuestions { get; set; }
        public bool ShuffleOptions { get; set; }
        public string? ShowResultsAt { get; set; }
        public string? StartsAt { get; set; } 
        public string? EndsAt { get; set; }
        public string? Status { get; set; }
        public int QuestionCount { get; set; }
    }

    public class CreateExamVM
    {
        public int GroupId { get; set; } 
        public string? Title { get; set; } 
        public string? Subject { get; set; }
        public int DurationMinutes { get; set; }
        public bool ShuffleQuestions { get; set; }
        public bool ShuffleOptions { get; set; }
        public string? ShowResultsAt { get; set; }
        public string? StartsAt { get; set; } 
        public string? EndsAt { get; set; }
        public List<string> QuestionIds { get; set; } = new();
    }

    public class UpdateExamVM
    {
        public string? Title { get; set; }
        public int? DurationMinutes { get; set; }
        public bool? ShuffleQuestions { get; set; }
        public bool? ShuffleOptions { get; set; }
        public string? ShowResultsAt { get; set; }
        public string? StartsAt { get; set; }
        public string? EndsAt { get; set; }
    }

}
