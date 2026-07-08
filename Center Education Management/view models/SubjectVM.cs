using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class SubjectDetailsVM
    {
        public int SubjectId { get; set; }
        public string? Name { get; set; }
        public string? CenterName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class CreateSubjectVM
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        public int CenterId { get; set; }
    }
    public class UpdateSubjectVM
    {
        [Required]
        public int SubjectId { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        public int CenterId { get; set; }
        public bool IsActive { get; set; }
    }
    public class LeadInterestedSubjectDetailsVM
    {
        public int LeadId { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SubjectName { get; set; }
        public string? StageName { get; set; }
        public string? CenterName { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
