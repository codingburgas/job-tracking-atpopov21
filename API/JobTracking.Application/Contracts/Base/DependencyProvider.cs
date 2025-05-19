using JobTracking.DataAccess.Persistence;

namespace JobTracking.Application.Contracts.Base;

public class DependencyProvider
{
    public AppDbContext Db { get; set; }
    
    public DependencyProvider(AppDbContext dbContext)
    {
        Db = dbContext;
    }
}