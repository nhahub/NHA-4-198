using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CreateCenterAdminVM
    {
        [Required]
        public int CenterId { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Phone { get; set; }

        public CenterAdminRole Role { get; set; }
        public double Salary { get; set; }

    }

    public class UpdateCenterAdminVM
    {
        [Required]
        public int Id { get; set; }

        public CenterAdminRole Role { get; set; }

        public bool IsActive { get; set; }

        public bool CanManageStudents { get; set; }

        public bool CanManageGroups { get; set; }

        public bool CanManagePayments { get; set; }

        public bool CanManageTeachers { get; set; }
        public double Salary { get; set; }

    }

    public class CenterAdminDetailsVM
    {
        public int Id { get; set; }

        public int CenterId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Role { get; set; }

        public string? GrantedBy { get; set; }

        public DateTime GrantedAt { get; set; }

        public bool IsActive { get; set; }

        public bool CanManageStudents { get; set; }

        public bool CanManageGroups { get; set; }

        public bool CanManagePayments { get; set; }

        public bool CanManageTeachers { get; set; }
        public double Salary { get; set; }

    }
}
