using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using Center_Education_managment.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class Centersubscription
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public int PlanId { get; set; }
        public virtual SubscriptionPlan? Plan { get; set; }
        public SubscriptionStatus Status { get; set; }
        public BillingCycle BillingCycle { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public int? ApprovedBy { get; set; }
        public virtual Superadmin? ApprovedByAdmin { get; set; }
        public DateTime? ApprovedAt { get; set; }
    }
}
    
