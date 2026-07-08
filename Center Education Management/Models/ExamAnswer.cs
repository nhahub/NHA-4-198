using Center_Education_Management.view_models;
using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class ExamAnswer
    {
        public int Id { get; set; }
        public int AttemptId { get; set; }
        public virtual ExamAttempt? Attempt { get; set; }
        public int ExamQuestionId { get; set; }
        public virtual ExamQuestion? ExamQuestion { get; set; }
        public virtual Teacher? GradedByTeacher { get; set; }
        public string? AnswerText { get; set; }
        public bool IsAutoGraded { get; set; }
        public decimal? EarnedPoints { get; set; }
        public int? GradedBy { get; set; }
        public DateTime? GradedAt { get; set; }
        public DateTime SavedAt { get; set; }
    }
}
