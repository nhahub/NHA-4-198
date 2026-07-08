using Center_Education_Management.Enums;
using System.ComponentModel.DataAnnotations;
namespace Center_Education_Management.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public AttendanceStatus Status { get; set; }
        public AttendanceMode AttendanceMode { get; set; }
        public int RecordedByID { get; set; }
        public int StudentId { get; set; }
        public int SessionId { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Session? Session { get; set; }
        public virtual User? RecordedByUser { get; set; }
        public virtual QRToken? QRToken { get; set; }
        public int? QRTokenId { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}
