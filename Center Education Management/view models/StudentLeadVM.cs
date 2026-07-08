using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class StudentLeadCreateVM
    {
        [Required]
        [MaxLength(150)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(150)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(150)]
        public string? InterestedStageOrSubject { get; set; }

        public int CenterId { get; set; }
    }

    public class StudentLeadUpdateVM
    {
        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? InterestedStageOrSubject { get; set; }

        public string? Status { get; set; }
    }

    public class StudentLeadReadVM
    {
        public int LeadId { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? InterestedStageOrSubject { get; set; }

        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CenterId { get; set; }

        public string? CenterName { get; set; }
    }
}
