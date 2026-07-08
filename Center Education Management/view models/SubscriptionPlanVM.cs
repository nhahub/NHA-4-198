using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CreateSubscriptionPlanVM
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal PriceMonthly { get; set; }
        public decimal PriceYearly { get; set; }
        public decimal PriceSemester { get; set; }
        [Required]
        public int MaxStudents { get; set; }
        [Required]
        public int MaxTeachers { get; set; }
        [Required]
        public int MaxGroups { get; set; }
        [Required]
        public int StorageGB { get; set; }
    }
    public class UpdateSubscriptionPlanVM
    {
        [Required]
        public int PlanId { get; set; }

        [Required]
        public string? Name { get; set; }

        public decimal PriceMonthly { get; set; }

        public decimal PriceYearly { get; set; }

        public decimal PriceSemester { get; set; }

        public int MaxStudents { get; set; }

        public int MaxTeachers { get; set; }

        public int MaxGroups { get; set; }

        public int StorageGB { get; set; }

        public bool IsActive { get; set; }
    }
    public class SubscriptionPlanVM
    {
        public int PlanId { get; set; }

        public string? Name { get; set; }

        public decimal PriceMonthly { get; set; }

        public decimal PriceYearly { get; set; }

        public decimal PriceSemester { get; set; }

        public int MaxStudents { get; set; }

        public int MaxTeachers { get; set; }

        public int MaxGroups { get; set; }

        public int StorageGB { get; set; }
        public bool IsActive { get; set; }

    }
}
