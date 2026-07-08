using Center_Education_managment.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CenterDetailsVM
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Slug { get; set; }

        public string? Description { get; set; }

        public string? LogoUrl { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Phone { get; set; }

        public string? Status { get; set; }

        public DateTime? VerifiedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string? OwnerName { get; set; }

        public string? VerifiedByAdminName { get; set; }
    }
    public class CreateCenterVM
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Slug { get; set; }

        public string? Description { get; set; }

        public string? LogoUrl { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        [Phone]
        public string? Phone { get; set; }
    }

    public class UpdateCenterVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Slug { get; set; }

        public string? Description { get; set; }

        public string? LogoUrl { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? Phone { get; set; }
    }
}
