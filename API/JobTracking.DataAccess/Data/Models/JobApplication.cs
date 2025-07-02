using System;
using System.ComponentModel.DataAnnotations;

namespace JobTracking.DataAccess.Data.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Job title cannot exceed 100 characters.")]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Company name cannot exceed 50 characters.")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
        public string Status { get; set; } // Example: Pending, Interviewed, Accepted, Rejected

        [DataType(DataType.Date)]
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
        
        public virtual User User { get; set; }
        public virtual JobAd JobAd { get; set; }
    }
}