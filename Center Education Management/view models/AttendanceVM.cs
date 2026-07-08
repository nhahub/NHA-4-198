using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CreateAttendanceVM
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int SessionId { get; set; }

        [Required]
        public AttendanceStatus Status { get; set; }

        [Required]
        public AttendanceMode AttendanceMode { get; set; }
    }

    public class UpdateAttendanceVM
    {
        [Required]
        public int AttendanceId { get; set; }

        [Required]
        public AttendanceStatus Status { get; set; }
    }

    public class AttendanceDetailsVM
    {
        public int AttendanceId { get; set; }

        public string? Status { get; set; }

        public string? AttendanceMode { get; set; }

        public string? StudentName { get; set; }

        public string? SessionTitle { get; set; }

        public string? RecordedByUserName { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}
