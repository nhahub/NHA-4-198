using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class AcademicSeasonVM
    {
        public int SeasonId { get; set; } 
        public int CenterId { get; set; } 
        public string? Name { get; set; } 
        public string? Type { get; set; }
        public string? StartsAt { get; set; } 
        public string? EndsAt { get; set; } 
        public string? Status { get; set; }
        public bool IsCurrent { get; set; }
    }

    public class CreateAcademicSeasonVM
    {
        public string Name { get; set; } = string.Empty;
        public AcademicSeasonType Type { get; set; }
        public string StartsAt { get; set; } = string.Empty;
        public string EndsAt { get; set; } = string.Empty;
    }

    public class UpdateAcademicSeasonVM
    {
        public string? Name { get; set; }
        public string? StartsAt { get; set; }
        public string? EndsAt { get; set; }
        public AcademicSeasonStatus? Status { get; set; }
        public bool? IsCurrent { get; set; }
    }
}
