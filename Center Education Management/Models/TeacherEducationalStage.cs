using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class TeacherEducationalStage
    {
        public int Id { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public int TeacherId { get; set; }
        public int StageId { get; set; }
        public virtual EducationalStage? Stage { get; set; }
    }
}
