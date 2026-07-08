using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class ParentDetailsVM
    {
        public int ParentId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public Permission Permissions { get; set; }

        public List<string>? StudentNames { get; set; }
    }
    public class CreateParentVM
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        public Permission Permissions { get; set; }
    }
    public class UpdateParentVM
    {
        [Required]
        public int ParentId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }

        public Permission Permissions { get; set; }
    }
    public class LinkParentToStudentsVM
    {
        [Required]
        public int ParentId { get; set; }

        [Required]
        public List<int> StudentIds { get; set; }
    }
}
