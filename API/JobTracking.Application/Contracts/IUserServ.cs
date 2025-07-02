using JobTracking.Domain.DTOs.Request;
using JobTracking.Domain.DTOs.Response;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;

namespace JobTracking.Application.Contracts;

public interface IUserServ
{
    Task<UserResponseDTO> GetUser(int userID);
    Task<IQueryable<UserResponseDTO>> GetUsers(BaseFilter<UserFilter> filter);
    Task<int> CreateUser(UserRequestDTO dto);
    Task<bool> UpdateUser(int id, UserRequestDTO dto);
    Task<bool> DeleteUser(int id);
}