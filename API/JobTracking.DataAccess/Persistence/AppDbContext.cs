using JobTracking.DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.DataAccess.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<JobAd> JobAds { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=JobTracker;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}