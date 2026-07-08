using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class ManualGradeDetailsVM
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? GroupName { get; set; }
        public string? SubjectName { get; set; }
        public string? AssistantName { get; set; }
        public decimal Points { get; set; }
        public string? Notes { get; set; }
        public DateTime GradedAt { get; set; }
    }
    public class CreateManualGradeVM
    {
        [Required]
        public Guid StudentId { get; set; }
        [Required]
        public Guid TeacherId { get; set; }
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public Guid SubjectId { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal Points { get; set; }
        public string? Notes { get; set; }
    }
    public class UpdateManualGradeVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal Points { get; set; }
        public string? Notes { get; set; }
    }
}
