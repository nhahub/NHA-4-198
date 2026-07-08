using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public int GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject? Subject { get; set; }
        public string? Title { get; set; }
        public int DurationMinutes { get; set; }
        public decimal TotalPoints { get; set; }
        public bool ShuffleQuestions { get; set; }
        public bool ShuffleOptions { get; set; }
        public DateTime? ShowResultsAt { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public ExamStatus Status { get; set; }
        public virtual ICollection<ExamQuestion> Questions { get; set; }
            = new List<ExamQuestion>();
        public virtual ICollection<ExamAttempt> Attempts { get; set; }
            = new List<ExamAttempt>();

    }
}
