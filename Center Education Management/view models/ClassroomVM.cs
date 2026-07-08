using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CreateClassroomVM
    {
        [Required]
        public int CenterId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(1, 500)]
        public int Capacity { get; set; }
        public ClassroomType Type { get; set; }
    }

    public class UpdateClassroomVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Range(1, 500)]
        public int Capacity { get; set; }

        public ClassroomType Type { get; set; }

        public bool IsActive { get; set; }
    }

    public class ClassroomDetailsVM
    {
        public int Id { get; set; }

        public int CenterId { get; set; }

        public string? Name { get; set; }

        public int Capacity { get; set; }

        public string? Type { get; set; }

        public bool IsActive { get; set; }

        public int SessionsCount { get; set; }
    }
}
