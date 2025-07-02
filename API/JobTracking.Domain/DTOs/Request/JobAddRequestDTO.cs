using System.ComponentModel.DataAnnotations;

namespace JobTracking.Domain.DTOs.Request;

public class JobAdRequestDTO
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [StringLength(50)]
    public string CompanyName { get; set; }

    [Required]
    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    [StringLength(50)]
    public string Location { get; set; }

    [Range(0, double.MaxValue)]
    public decimal SalaryRange { get; set; }
}
