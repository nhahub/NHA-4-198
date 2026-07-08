using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CreateTeacherAssistantVM
    {
        [Required]
        public int CenterId { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Phone { get; set; }

        public bool CanUpload { get; set; }

        public bool CanGrade { get; set; }

        public bool CanApproveRequests { get; set; }
        public double Salary { get; set; }

    }

    public class UpdateTeacherAssistantVM
    {
        [Required]
        public int Id { get; set; }

        public bool CanUpload { get; set; }

        public bool CanGrade { get; set; }

        public bool CanApproveRequests { get; set; }

        public bool IsActive { get; set; }
        public double Salary { get; set; }
    }

    public class TeacherAssistantDetailsVM
    {
        public int Id { get; set; }

        public int CenterId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool CanUpload { get; set; }

        public bool CanGrade { get; set; }

        public bool CanApproveRequests { get; set; }

        public bool IsActive { get; set; }

        public DateTime JoinedAt { get; set; }

        public int GroupsAssignedCount { get; set; }
        public double Salary { get; set; }

    }
}
