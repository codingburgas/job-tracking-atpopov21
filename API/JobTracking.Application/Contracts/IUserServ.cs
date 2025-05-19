using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request;

namespace JobTracking.Application.Contracts;

public interface IUserServ
{
    public Task<List<User>> GetAllUsers(int age, string name);
    public Task<UserResponseDTO> GetUser(int userID);
}