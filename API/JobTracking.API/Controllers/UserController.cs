using JobTracking.Application.Contracts;
using JobTracking.DataAccess.Data.Models;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : Controller
{
    private readonly IUserServ _userServ;
    public UserController(IUserServ userServ)
    {
        _userServ = userServ;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _userServ.GetUser(id));
    }

    [HttpPost]
    public async Task<IActionResult> GetUsers([FromBody] BaseFilter<UserFilter> filter)
    {
        return Ok(await _userServ.GetUsers(filter));
    }
}