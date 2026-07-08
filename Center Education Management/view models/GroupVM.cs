using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CreateGroupVM
    {
        [Required]
        [StringLength(150)]
        public string? Name { get; set; }
        [Required]
        [Range(1, 500)]
        public int MaxCapacity { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int SeasonId { get; set; }
        [Required]
        public int CenterId { get; set; }
        [Required]
        public int StageId { get; set; }
    }

    public class UpdateGroupVM
    {
        [Required]
        public int GroupId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int MaxCapacity { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int SeasonId { get; set; }

        [Required]
        public int StageId { get; set; }
    }
    public class GroupDetailsVM
    {
        public int GroupId { get; set; }
        public string? Name { get; set; }
        public int MaxCapacity { get; set; }
        public string? TeacherName { get; set; }
        public string? SubjectName { get; set; }
        public string? SeasonName { get; set; }
        public string? CenterName { get; set; }
        public string? StageName { get; set; }
        public int StudentCount { get; set; }
    }
    public class GroupListVM
    {
        public int GroupId { get; set; }
        public string? Name { get; set; }
        public int MaxCapacity { get; set; }
        public int EnrolledCount { get; set; }
    }
}
