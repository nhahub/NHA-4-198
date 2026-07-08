using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Models
{
    public class EducationalStage
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int LevelNumber { get; set; }
        public string? DisplayName { get; set; }
        public string? EducationSystem { get; set; }
        public bool IsActive { get; set; }
        public virtual User? UploadedByUser { get; set; }
        public virtual ICollection<Student> Students { get; set; }
            = new List<Student>();
        public virtual ICollection<Group> Groups { get; set; }
            = new List<Group>();
        public virtual ICollection<StudentLead> Leads { get; set; }
            = new List<StudentLead>();
        public virtual ICollection<TeacherEducationalStage> TeacherStages { get; set; }
            = new List<TeacherEducationalStage>();
        public virtual ICollection<Subject> Subjects { get; set; }
            = new List<Subject>();
    }
}
