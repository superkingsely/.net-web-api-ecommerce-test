using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _service;

    public UsersController(UserService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id) =>
        Ok(await _service.GetUser(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers() =>
        Ok(await _service.GetUsers());

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user) =>
        Ok(await _service.CreateUser(user));

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> UpdateUser(int id, User user)
    {
        if (id != user.Id) return BadRequest();
        return Ok(await _service.UpdateUser(user));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _service.DeleteUser(id);
        return NoContent();
    }
}