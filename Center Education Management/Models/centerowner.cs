using Center_Education_Management.Enums;
using Center_Education_managment.Enums;
using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class CenterOwner : User
    {
        public OwnershipType OwnershipType { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public PaymentMethod DefaultPaymentMethod { get; set; }
        public DateTime JoinedAt { get; set; }
        public virtual Center? center { get; set; }
        public virtual ICollection<Paymentgetway> PaymentGateways { get; set; }
            = new List<Paymentgetway>();
        public virtual ICollection<CenterAdmin> CenterAdmins { get; set; }
            = new List<CenterAdmin>();
    }
}
