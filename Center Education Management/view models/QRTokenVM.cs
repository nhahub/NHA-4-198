using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Education_Management.view_models
{
    public class GenerateQRTokenVM
    {
        [Required]
        public int SessionId { get; set; }
    }

    public class QRTokenDetailsVM
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public string? Token { get; set; }
        public string? GeneratedBy { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string? Status { get; set; }
        public bool IsExpired { get; set; }
        public int RemainingSeconds { get; set; }
    }
}
