using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class SessionDetailsVM
    {
        public int SessionId { get; set; }
        public string? Title { get; set; }
        public string? TeacherName { get; set; }
        public string? GroupName { get; set; }
        public string? classroom { get; set; }
        public List<AttendanceDetailsVM>? Attendances { get; set; }
    }
    public class CreateSessionVM
    {
        public string? Title { get; set; }
        public string? VideoLink { get; set; }

        public int GroupId { get; set; }
        public int TeacherId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }


}
