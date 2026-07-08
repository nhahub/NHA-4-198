using Center_Education_Management.Enums;
using Center_Education_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Center_Education_Management.Models
{
    public class Content
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public int GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public int SessionId { get; set; }
        public virtual Session? Session { get; set; }
        public int UploadedByID { get; set; }
        public virtual User? UploadedByUser { get; set; }
        public ContentType Type { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public long SizeBytes { get; set; }
        public ContentVisibility Visibility { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
