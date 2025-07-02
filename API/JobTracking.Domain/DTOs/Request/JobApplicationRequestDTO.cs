using System.ComponentModel.DataAnnotations;

namespace JobTracking.Domain.DTOs.Request;

public class JobApplicationRequestDTO
{
    
    [Required]
    public int UserId { get; set; }

    [Required]
    [StringLength(100)]
    public string JobTitle { get; set; }

    [Required]
    [StringLength(50)]
    public string CompanyName { get; set; }

}