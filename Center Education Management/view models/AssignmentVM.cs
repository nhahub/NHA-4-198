using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class AssignmentReadVM
    {
        public int AssignmentId { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string? TeacherName { get; set; }
        public string? GroupName { get; set; }
        public string? Status { get; set; }
    }
    public class CreateAssignmentVM
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
    public class UpdateAssignmentVM
    {
        [Required]
        public int AssignmentId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public AssignmentStatus Status { get; set; }
    }
}
