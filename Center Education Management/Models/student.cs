using Center_Education_Management.Models;
using Center_Education_Management.view_models;
using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class Student : User
    {
        public int ParentId { get; set; }
        public virtual Parent? Parent { get; set; }
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public string? StudentCode { get; set; }
        public int StageId { get; set; }
        public virtual EducationalStage? Stage { get; set; }
        public StudentStatus Status { get; set; }
        public string? BlockedReason { get; set; }
        public DateTime JoinedAt { get; set; }
        public virtual ICollection<Enrollment> GroupEnrollments { get; set; }
            = new List<Enrollment>();
        public virtual ICollection<ExamAttempt> ExamAttempts { get; set; }
            = new List<ExamAttempt>();
        public virtual ICollection<Payment> Payments { get; set; }
            = new List<Payment>();
        public virtual ICollection<Attendance> Attendances { get; set; }
            = new List<Attendance>();
    }
}
