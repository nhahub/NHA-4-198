using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class ManualGrade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public int RecordedById { get; set; }
        public virtual User? RecordedByUser { get; set; }
        public int GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject? Subject { get; set; }
        public decimal Points { get; set; }
        public string? Notes { get; set; }
        public DateTime GradedAt { get; set; }
    }
}
