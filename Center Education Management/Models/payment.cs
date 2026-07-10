using Center_Education_Management.Model;
using Center_Education_managment.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public int CenterId { get; set; }
        public virtual Center? Center { get; set; }
        public int? GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public string? GatewayRef { get; set; }
        public int? RecordedBy { get; set; }
        public virtual User? RecordedByUser { get; set; }
        public DateTime PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual CenterAdmin? centeradmin { get; set; }
        public int PaymentGatewayId { get; set; }
        public virtual Paymentgetway? PaymentGateway { get; set; }
    }
}
