using Center_Education_managment.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CenterSubscriptionDetailsVM
    {
        public int SubscriptionId { get; set; }

        public string? Status { get; set; }

        public string? BillingCycle { get; set; }

        public DateTime StartsAt { get; set; }

        public DateTime EndsAt { get; set; }

        public DateTime? ApprovedAt { get; set; }

        public string? CenterName { get; set; }

        public string? PlanName { get; set; }

        public string? ApprovedByAdminName { get; set; }
    }
    public class CreateCenterSubscriptionVM
    {
        [Required]
        public int CenterId { get; set; }

        [Required]
        public int PlanId { get; set; }

        [Required]
        public BillingCycle BillingCycle { get; set; }
    }
    public class ApproveCenterSubscriptionVM
    {
        [Required]
        public int SubscriptionId { get; set; }

        [Required]
        public SubscriptionStatus Status { get; set; }
    }
}
