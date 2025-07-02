namespace JobTracking.Domain.DTOs.Response;

public class JobApplicationResponseDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string JobTitle { get; set; }
    public string CompanyName { get; set; }
    public string Status { get; set; }
    public DateTime AppliedDate { get; set; }
}