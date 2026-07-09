using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal PriceMonthly { get; set; }
        public decimal PriceYearly { get; set; }
        public decimal PriceSemester { get; set; }
        public int MaxStudents { get; set; }
        public int MaxTeachers { get; set; }
        public int MaxGroups { get; set; }
        public int StorageGB { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Centersubscription> CenterSubscriptions { get; set; }
        = new List<Centersubscription>();
    }
}
