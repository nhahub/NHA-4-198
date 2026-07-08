using Center_Education_Management.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class CreateContentVM
    {
        [Required]
        public int GroupId { get; set; }

        public int SessionId { get; set; }

        [Required]
        public ContentType Type { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Url { get; set; }

        public ContentVisibility Visibility { get; set; }
    }

    public class UpdateContentVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Url { get; set; }

        public ContentVisibility Visibility { get; set; }
    }

    public class ContentDetailsVM
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public int SessionId { get; set; }

        public int UploadedBy { get; set; }

        public string? Type { get; set; }

        public string? Title { get; set; }

        public string? Url { get; set; }

        public long SizeBytes { get; set; }

        public string? Visibility { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? UploadedByName { get; set; }

        public string? GroupName { get; set; }

        public string? SessionTitle { get; set; }
    }
}
