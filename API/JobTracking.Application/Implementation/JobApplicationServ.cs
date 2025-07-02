using JobTracking.Application.Contracts;
using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request;
using JobTracking.Domain.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Application.Implementation;

public class JobApplicationServ : IJobApplicationServ
{
    protected DependencyProvider Provider { get; set; }

    public JobApplicationServ(DependencyProvider provider)
    {
        Provider = provider;
    }

    public async Task<List<JobApplicationResponseDTO>> GetAllAsync()
    {
        return await Provider.Db.JobApplications
            .Select(app => new JobApplicationResponseDTO
            {
                Id = app.Id,
                UserId = app.UserId,
                JobTitle = app.JobTitle,
                CompanyName = app.CompanyName,
                Status = app.Status,
                AppliedDate = app.AppliedDate
            })
            .ToListAsync();
    }

    public async Task<List<JobApplicationResponseDTO>> GetByUserIdAsync(int userId)
    {
        return await Provider.Db.JobApplications
            .Where(app => app.UserId == userId)
            .Select(app => new JobApplicationResponseDTO
            {
                Id = app.Id,
                UserId = app.UserId,
                JobTitle = app.JobTitle,
                CompanyName = app.CompanyName,
                Status = app.Status,
                AppliedDate = app.AppliedDate
            })
            .ToListAsync();
    }

    public async Task<JobApplicationResponseDTO?> GetByIdAsync(int id)
    {
        return await Provider.Db.JobApplications
            .Where(app => app.Id == id)
            .Select(app => new JobApplicationResponseDTO
            {
                Id = app.Id,
                UserId = app.UserId,
                JobTitle = app.JobTitle,
                CompanyName = app.CompanyName,
                Status = app.Status,
                AppliedDate = app.AppliedDate
            })
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateAsync(JobApplicationRequestDTO dto)
    {
        var userExists = await Provider.Db.Users.AnyAsync(u => u.Id == dto.UserId);
        if (!userExists)
            throw new ArgumentException("User does not exist.");

        var jobExists = await Provider.Db.JobAds.AnyAsync(j => j.Title == dto.JobTitle && j.CompanyName == dto.CompanyName);
        if (!jobExists)
            throw new ArgumentException("Job ad does not exist.");

        var exists = await Provider.Db.JobApplications.AnyAsync(a =>
            a.UserId == dto.UserId &&
            a.JobTitle == dto.JobTitle &&
            a.CompanyName == dto.CompanyName);

        if (exists)
            throw new InvalidOperationException("User has already applied for this job.");

        var application = new JobApplication
        {
            UserId = dto.UserId,
            JobTitle = dto.JobTitle,
            CompanyName = dto.CompanyName,
            Status = "Подадена",
            AppliedDate = DateTime.UtcNow
        };

        Provider.Db.JobApplications.Add(application);
        await Provider.Db.SaveChangesAsync();
        return application.Id;
    }

    public async Task<bool> UpdateStatusAsync(int id, string newStatus)
    {
        var validStatuses = new[] { "Подадена", "Одобрена за интервю", "Отказана" };
        if (!validStatuses.Contains(newStatus))
            throw new ArgumentException("Invalid status.");

        var application = await Provider.Db.JobApplications.FindAsync(id);
        if (application == null) return false;

        application.Status = newStatus;
        await Provider.Db.SaveChangesAsync();
        return true;
    }


    public async Task<bool> DeleteAsync(int id)
    {
        var application = await Provider.Db.JobApplications.FindAsync(id);
        if (application == null) return false;

        Provider.Db.JobApplications.Remove(application);
        await Provider.Db.SaveChangesAsync();
        return true;
    }
}