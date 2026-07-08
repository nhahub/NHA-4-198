using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class EnrollmentDetailsVM
    {
        public int EnrollmentId { get; set; }

        public string? Status { get; set; }

        public string? CenterName { get; set; }

        public string? StudentName { get; set; }

        public string? GroupName { get; set; }
    }
    public class CreateEnrollmentVM
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int GroupId { get; set; }
    }
    internal class UpdateEnrollmentStatusVM
    {
        [Required]
        public int EnrollmentId { get; set; }

        [Required]
        public EnrollmentStatus Status { get; set; }
    }
}
