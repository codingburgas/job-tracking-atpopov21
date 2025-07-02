using JobTracking.Application.Contracts;
using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request;
using JobTracking.Domain.DTOs.Response;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Application.Implementation;

public class UserServ : IUserServ
{
    protected DependencyProvider Provider { get; set; }

    public UserServ(DependencyProvider provider)
    {
        Provider = provider;
    }

    public async Task<UserResponseDTO?> GetUser(int userID)
    {
        return await Provider.Db.Users
            .Where(x => x.Id == userID)
            .Select(u => new UserResponseDTO
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.Role,
                CreatedAt = u.CreatedAt
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IQueryable<UserResponseDTO>> GetUsers(BaseFilter<UserFilter> filter)
    {
        IQueryable<User> query = Provider.Db.Users;
        UserFilter? userFilter = filter.Filters;

        if (userFilter != null)
        {
            if (!string.IsNullOrEmpty(userFilter.Name))
            {
                query = query.Where(x => x.FirstName.Contains(userFilter.Name) || x.LastName.Contains(userFilter.Name));
            }

            if (!string.IsNullOrEmpty(userFilter.Email))
            {
                query = query.Where(x => x.Email.Contains(userFilter.Email));
            }

            if (!string.IsNullOrEmpty(userFilter.Role))
            {
                query = query.Where(x => x.Role.Contains(userFilter.Role));
            }

            if (userFilter.CreatedAt != null)
            {
                query = query.Where(x => x.CreatedAt.Date == userFilter.CreatedAt.Value.Date);
            }
        }

        query = query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);

        return query.Select(x => new UserResponseDTO
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            Role = x.Role,
            CreatedAt = x.CreatedAt
        });
    }

    public async Task<int> CreateUser(UserRequestDTO dto)
    {
        if (await Provider.Db.Users.AnyAsync(u => u.Email == dto.Email))
            throw new InvalidOperationException("Email already exists.");

        var validRoles = new[] { "Admin", "User" };
        if (!validRoles.Contains(dto.Role))
            throw new ArgumentException("Invalid role.");
        
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Role = dto.Role,
            CreatedAt = DateTime.UtcNow,
            Password = hashedPassword
        };

        Provider.Db.Users.Add(user);
        await Provider.Db.SaveChangesAsync();
        return user.Id;
    }

    public async Task<bool> UpdateUser(int id, UserRequestDTO dto)
    {
        var user = await Provider.Db.Users.FindAsync(id);
        if (user == null) return false;

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.Role = dto.Role;
        await Provider.Db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await Provider.Db.Users.FindAsync(id);
        if (user == null) return false;

        Provider.Db.Users.Remove(user);
        await Provider.Db.SaveChangesAsync();
        return true;
    }
}
