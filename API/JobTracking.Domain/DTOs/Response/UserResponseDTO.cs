using System.ComponentModel.DataAnnotations;

namespace JobTracking.Domain.DTOs.Response;

public class UserResponseDTO
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must contain upper, lower case letters and a number.")]
    public string Password { get; set; }

    
    [Required]
    [StringLength(20, ErrorMessage = "Role cannot exceed 20 characters.")]
    public string Role { get; set; } // Example: Admin, Employee, Manager

    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}