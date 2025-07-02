using JobTracking.Domain.DTOs.Request;
using JobTracking.Domain.DTOs.Response;

namespace JobTracking.Application.Contracts;

public interface IJobAddServ
{
    
    Task<List<JobAdResponseDTO>> GetAllAsync();
    Task<JobAdResponseDTO?> GetByIdAsync(int id);
    Task<int> CreateAsync(JobAdRequestDTO dto);
    Task<bool> UpdateAsync(int id, JobAdRequestDTO dto);
    Task<bool> DeleteAsync(int id);

}