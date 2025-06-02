using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.Application.Contracts;

public interface IUserServ
{
    public Task<List<User>> GetAllUsers(int age, string name);
    public Task<UserResponseDTO> GetUser(int userID);
    public Task<UserResponseDTO> GetUsers([FromBody] BaseFilter<UserFilter> filter);
}