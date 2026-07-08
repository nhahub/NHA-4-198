using Center_Education_managment.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class PaymentDetailsVM
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? CenterName { get; set; }
        public string? GroupName { get; set; }
        public decimal Amount { get; set; }
        public string? Method { get; set; }
        public string? Status { get; set; }
        public string? GatewayName { get; set; }
        public string? RecordedByUserName { get; set; }
        public DateTime PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class CreatePaymentVM
        {
            public int StudentId { get; set; }
            public int CenterId { get; set; }
            public int GroupId { get; set; }
    
            public decimal Amount { get; set; }
    
            public PaymentMethod Method { get; set; }
    
            public int GatewayId { get; set; }
    }
    public class UpdatePaymentStatusVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }
    }
    public class PaymentListVM
    {
        public int Id { get; set; }

        public string? StudentName { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatus Status { get; set; }

        public DateTime PaidAt { get; set; }
    }
}
