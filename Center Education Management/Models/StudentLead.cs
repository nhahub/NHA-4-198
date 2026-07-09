using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class StudentLead
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public string? Phone { get; set; } 
        public string? Email { get; set; }
        public string? InterestedStageOrSubject { get; set; } 
        public StudentLeadStatus Status { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public virtual EducationalStage? Stage { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject? Subject { get; set; }
        public int StageId { get; set; }

    }
}
