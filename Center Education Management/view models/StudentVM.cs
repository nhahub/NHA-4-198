using Center_Education_Management.Enums;
using Center_Education_managment.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CreateStudentVM
    {
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public int CenterId { get; set; }
        [Required]
        public int StageId { get; set; }
        [Required]
        public int ParentId { get; set; }
        public string? StudentCode { get; set; }
    }
    public class UpdateStudentVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int StageId { get; set; }
        public string? StudentCode { get; set; }
        public StudentStatus Status { get; set; }
    }
    public class StudentDetailsVM
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CenterName { get; set; }
        public string? StageName { get; set; }
        public string? Status { get; set; }
        public string? BlockedReason { get; set; }
        public DateTime JoinedAt { get; set; }
    }
    public class StudentListVM
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }
        public StudentStatus Status { get; set; }
        public string? StageName { get; set; }
    }
}
