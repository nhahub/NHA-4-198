using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class TeacherdetilesVM
    {
        public int TeacherId { get; set; }
        public int CenterId { get; set; }
        public string? Centername { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Subjectname { get; set; }
        public string? Bio { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoinedAt { get; set; }
        public DateTime? LeftAt { get; set; }
        public int TotalGroups { get; set; }
        public int TotalStudents { get; set; }
        public double Salary { get; set; }

    }

    public class CreateTeacherVM
    {
        [Required]
        [StringLength(100)]
        public string? FullName { get; set; }

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

        public string? Subject { get; set; }

        public string? Bio { get; set; }
        public double Salary { get; set; }

    }
    public class UpdateTeacherVM
    {
        [Required]
        public int TeacherId { get; set; }

        public string? Subject { get; set; }

        public string? Bio { get; set; }

        public bool IsActive { get; set; }
        public double Salary { get; set; }

    }
}
