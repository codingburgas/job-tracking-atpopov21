using JobTracking.Application.Contracts;
using JobTracking.Application.Contracts.Base;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.DTOs.Request;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTracking.Application.Implementation;

public class UserServ : IUserServ
{
    protected DependencyProvider Provider { get; set; }
    
    public UserServ(DependencyProvider provider)
    {
        Provider = provider;
    }

    public Task<List<User>> GetAllUsers(int age, string name)
    {
        return Provider.Db.Users
            .Skip((age - 1) * 10)
            .Take(10)
            .ToListAsync();
        
        /*query = query.Where(u => u.Name == "admin");

        var result = query.ToList();
        var result = query.ToArray();
        var result = query.ToDictionary();
        var result = query.ToLookup();
        var resultList = query.ToList();
        var resultArr = query.ToArray();
        var resultDict = query.ToDictionary();
        var resultLookup = query.ToLookup();*/
    }

    public Task<UserResponseDTO?> GetUser(int userID)
    {
        var result = (from user in Provider.Db.Users
            where user.Id == userID
            select new UserResponseDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                CreatedAt = user.CreatedAt,
            })
            .FirstAsync();
        
        return Provider.Db.Users
            .Where(x => x.Id == userID)
            .Select(u => new UserResponseDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role,
                CreatedAt = u.CreatedAt,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IQueryable<UserResponseDTO>> GetUsers(BaseFilter<UserFilter> filter)
    {
        IQueryable<User> query = Provider.Db.Users;
        UserFilter? userFilter = filter.Filters;

        if (userFilter != null)
        {
            if (string.IsNullOrEmpty(userFilter.Name))
            {
                query = query.Where(x => x.Name.Contains(userFilter.Name));
            }

            if (string.IsNullOrEmpty(userFilter.Email))
            {
                query = query.Where(x => x.Email.Contains(userFilter.Email));
            }

            if (string.IsNullOrEmpty(userFilter.Role))
            {
                query = query.Where(x => x.Role.Contains(userFilter.Role));
            }

            if (userFilter.CreatedAt == null)
            {
                query = query.Where(x => x.CreatedAt.ToString().Contains(userFilter.CreatedAt.ToString()));
            }
        }
        
        query = query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        return query.Select(x => new UserResponseDTO()
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            Role = x.Role,
            CreatedAt = x.CreatedAt
        });
    }
}