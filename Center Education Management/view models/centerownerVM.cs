using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CenterOwnerDetailsVM
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string NationalID { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string? AvatarUrl { get; set; }

        public string OwnershipType { get; set; }

        public string SubscriptionStatus { get; set; }

        public string DefaultPaymentMethod { get; set; }

        public DateTime JoinedAt { get; set; }
        public string? CenterName { get; set; }
    }

    public class UpdateCenterOwnerVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public string? AvatarUrl { get; set; }

        [Required]
        public string OwnershipType { get; set; }

        [Required]
        public string DefaultPaymentMethod { get; set; }
    }

    public class RegisterCenterOwnerVM
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string NationalID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }
        public string DefaultPaymentMethod { get; set; }
        public string OwnershipType { get; set; }


    }
}
