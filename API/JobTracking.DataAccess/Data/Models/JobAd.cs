using System;
using System.ComponentModel.DataAnnotations;

namespace JobTracking.DataAccess.Data.Models
{
    public class JobAd
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Company Name cannot exceed 50 characters.")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Location cannot exceed 50 characters.")]
        public string Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public decimal SalaryRange { get; set; }
    }
}