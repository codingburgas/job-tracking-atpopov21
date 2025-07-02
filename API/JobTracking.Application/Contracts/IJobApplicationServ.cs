using JobTracking.Domain.DTOs.Request;
using JobTracking.Domain.DTOs.Response;

namespace JobTracking.Application.Contracts;

public interface IJobApplicationServ
{
    
    Task<List<JobApplicationResponseDTO>> GetAllAsync();
    Task<List<JobApplicationResponseDTO>> GetByUserIdAsync(int userId);
    Task<JobApplicationResponseDTO?> GetByIdAsync(int id);
    Task<int> CreateAsync(JobApplicationRequestDTO dto);
    Task<bool> UpdateStatusAsync(int id, string newStatus);
    Task<bool> DeleteAsync(int id);

}