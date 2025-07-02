using JobTracking.Application.Contracts;
using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request;
using JobTracking.Domain.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Application.Implementation;
public class JobAdService : IJobAddServ
{
    protected DependencyProvider Provider { get; set; }

    public JobAdService(DependencyProvider provider)
    {
        Provider = provider;
    }

    public async Task<List<JobAdResponseDTO>> GetAllAsync()
    {
        return await Provider.Db.JobAds
            .Select(ad => new JobAdResponseDTO
            {
                Id = ad.Id,
                Title = ad.Title,
                CompanyName = ad.CompanyName,
                Description = ad.Description,
                Location = ad.Location,
                PostedDate = ad.PostedDate,
                SalaryRange = ad.SalaryRange
            })
            .ToListAsync();
    }

    public async Task<JobAdResponseDTO?> GetByIdAsync(int id)
    {
        return await Provider.Db.JobAds
            .Where(ad => ad.Id == id)
            .Select(ad => new JobAdResponseDTO
            {
                Id = ad.Id,
                Title = ad.Title,
                CompanyName = ad.CompanyName,
                Description = ad.Description,
                Location = ad.Location,
                PostedDate = ad.PostedDate,
                SalaryRange = ad.SalaryRange
            })
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateAsync(JobAdRequestDTO dto)
    {
        var exists = await Provider.Db.JobAds.AnyAsync(ad =>
            ad.Title == dto.Title &&
            ad.CompanyName == dto.CompanyName &&
            ad.Location == dto.Location);

        if (exists)
            throw new InvalidOperationException("Job ad already exists.");

        var jobAd = new JobAd
        {
            Title = dto.Title,
            CompanyName = dto.CompanyName,
            Description = dto.Description,
            Location = dto.Location,
            PostedDate = DateTime.UtcNow,
            SalaryRange = dto.SalaryRange
        };

        Provider.Db.JobAds.Add(jobAd);
        await Provider.Db.SaveChangesAsync();
        return jobAd.Id;
    }

    public async Task<bool> UpdateAsync(int id, JobAdRequestDTO dto)
    {
        var jobAd = await Provider.Db.JobAds.FindAsync(id);
        if (jobAd == null) return false;

        jobAd.Title = dto.Title;
        jobAd.CompanyName = dto.CompanyName;
        jobAd.Description = dto.Description;
        jobAd.Location = dto.Location;
        jobAd.SalaryRange = dto.SalaryRange;

        await Provider.Db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var jobAd = await Provider.Db.JobAds.FindAsync(id);
        if (jobAd == null) return false;

        Provider.Db.JobAds.Remove(jobAd);
        await Provider.Db.SaveChangesAsync();
        return true;
    }
}
