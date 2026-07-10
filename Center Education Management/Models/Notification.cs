using Center_Education_Management.Enums;
using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public NotificationType? Type { get; set; }
        public string? Title { get; set; } 
        public string? Body { get; set; } 
        public bool IsRead { get; set; } 
        public string? RefType { get; set; }
        public int? RefId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
