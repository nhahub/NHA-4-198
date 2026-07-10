using Center_Education_Management.Enums;
using Center_Education_Management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.Model
{
    public class CenterAdmin : User
    {
        public virtual Center? Center { get; set; }
        public int CenterId { get; set; }
        public CenterAdminRole Role { get; set; }

        public virtual CenterOwner? GrantedBy { get; set; }
        public int GrantedById { get; set; }
        public DateTime GrantedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
