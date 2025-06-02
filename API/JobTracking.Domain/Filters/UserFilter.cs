using JobTracking.Domain.Filters.Base;

namespace JobTracking.Domain.Filters;

public class UserFilter : IFilter
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}