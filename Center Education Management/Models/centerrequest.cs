using Center_Education_Management.Enums;
using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class Centerrequest
    {
        public int Id { get; set; }
        public string? CenterName { get; set; }
        public string? ContactPhone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? ReviewedById { get; set; }
        public CenterRequestStatus State { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Superadmin? ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }
    }
}
