using Center_Education_Management.Enums;
using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class QRToken
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public virtual Session? Session { get; set; }
        public virtual User? GenrateUser { get; set; }
        public int GeneratedById { get; set; }
        public string? Token { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public QRTokenStatus Status { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
            = new List<Attendance>();
    }
}
