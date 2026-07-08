using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CenterRequestDetailsVM
    {
        public int Id { get; set; }

        public string? CenterName { get; set; }

        public string? ContactPhone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ReviewedAt { get; set; }

        public string? ReviewedByAdminName { get; set; }
    }
    public class CreateCenterRequestVM
    {
        [Required]
        [StringLength(150)]
        public string? CenterName { get; set; }

        [Required]
        [Phone]
        public string? ContactPhone { get; set; }


        [Required]
        public string? Address { get; set; }

        [Required]
        public string? City { get; set; }
    }
    public class ReviewCenterRequestVM
    {
        [Required]
        public int RequestId { get; set; }

        [Required]
        public CenterRequestStatus State { get; set; }
    }
}
