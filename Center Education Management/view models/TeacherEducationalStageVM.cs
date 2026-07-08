using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class TeacherEducationalStageDetailsVM
    {
        public int TeacherId { get; set; }
        public string? TeacherName { get; set; }
        public int StageId { get; set; }
        public string? StageName { get; set; }
        public string? SubjectName { get; set; }
        public string? CenterName { get; set; }
    }
    public class CreateTeacherEducationalStageVM
    {
        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int StageId { get; set; }
    }
}
