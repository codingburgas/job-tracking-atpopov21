using JobTracking.Application.Contracts;
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
}