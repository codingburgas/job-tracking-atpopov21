namespace JobTracking.Domain.DTOs.Response;

public class JobAdResponseDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CompanyName { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime PostedDate { get; set; }
    public decimal SalaryRange { get; set; }
}
