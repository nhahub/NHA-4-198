using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class NotificationCreateVM
    {
        public int UserId { get; set; }

        public NotificationType Type { get; set; }

        public string? Title { get; set; }

        public string? Body { get; set; }

        public string? RefType { get; set; }

        public int? RefId { get; set; }
    }

    public class NotificationReadVM
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Type { get; set; }

        public string? Title { get; set; }

        public string? Body { get; set; }

        public bool IsRead { get; set; }

        public string? RefType { get; set; }

        public int? RefId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
