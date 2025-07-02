using JobTracking.Application.Contracts;
using JobTracking.Domain.DTOs.Request;
using JobTracking.Domain.Filters;
using JobTracking.Domain.Filters.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.API.Controllers;


[Authorize(Roles = "User, Admin")]
[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserServ _userServ;

    public UserController(IUserServ userServ)
    {
        _userServ = userServ;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userServ.GetUser(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> GetUsers([FromBody] BaseFilter<UserFilter> filter)
    {
        var users = await _userServ.GetUsers(filter);
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserRequestDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var id = await _userServ.CreateUser(dto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserRequestDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var success = await _userServ.UpdateUser(id, dto);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _userServ.DeleteUser(id);
        if (!success) return NotFound();
        return NoContent();
    }
}