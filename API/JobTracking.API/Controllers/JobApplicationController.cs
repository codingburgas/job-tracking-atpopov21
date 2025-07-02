using JobTracking.Application.Contracts;
using JobTracking.Domain.DTOs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.API.Controllers;


[Authorize(Roles = "User")]
[ApiController]
[Route("api/[controller]/[action]")]
public class JobApplicationController : ControllerBase
{
    private readonly IJobApplicationServ _jobApplicationService;

    public JobApplicationController(IJobApplicationServ jobApplicationService)
    {
        _jobApplicationService = jobApplicationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _jobApplicationService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUser(int userId)
    {
        var result = await _jobApplicationService.GetByUserIdAsync(userId);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _jobApplicationService.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] JobApplicationRequestDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var id = await _jobApplicationService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
    {
        var success = await _jobApplicationService.UpdateStatusAsync(id, status);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _jobApplicationService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
