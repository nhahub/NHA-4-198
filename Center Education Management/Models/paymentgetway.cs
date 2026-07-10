using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class Paymentgetway
    {
        public int Id { get; set; }
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public int OwnerId { get; set; }
        public PaymentProvider Provider { get; set; }
        public virtual CenterOwner? Owner { get; set; }
        public string? Credentials { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
            = new List<Payment>();
    }
}
