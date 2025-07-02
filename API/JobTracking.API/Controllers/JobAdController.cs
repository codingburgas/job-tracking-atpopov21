using JobTracking.Domain.DTOs.Request;
using JobTracking.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JobTracking.API.Controllers;


[ApiController]
[Route("api/[controller]/[action]")]
public class JobAdController : ControllerBase
{
    private readonly IJobAddServ _jobAdService;

    public JobAdController(IJobAddServ jobAdService)
    {
        _jobAdService = jobAdService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _jobAdService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _jobAdService.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] JobAdRequestDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var id = await _jobAdService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] JobAdRequestDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var success = await _jobAdService.UpdateAsync(id, dto);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _jobAdService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
