using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CreateEducationalStageVM
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        public int LevelNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string? DisplayName { get; set; }
        [Required]
        public EducationSystemType EducationSystem { get; set; }
    }

    public class UpdateEducationalStageVM
    {
        [Required]
        public int StageId { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        [Required]
        public int LevelNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string? DisplayName { get; set; }
        [Required]
        public EducationSystemType EducationSystem { get; set; }
        public bool IsActive { get; set; }
    }

    public class EducationalStageDetailsVM
    {
        public int StageId { get; set; }
        public string? Name { get; set; }
        public int LevelNumber { get; set; }
        public string? DisplayName { get; set; }
        public string? EducationSystem { get; set; }
        public bool IsActive { get; set; }
        public int StudentsCount { get; set; }
        public int GroupsCount { get; set; }
    }
}
