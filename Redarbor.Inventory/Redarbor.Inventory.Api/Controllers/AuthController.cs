using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redarbor.Inventory.Application.Interfaces;
namespace Redarbor.Inventory.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("login")]
    public IActionResult Login([FromBody] string username)
    {
        if (string.IsNullOrEmpty(username)) return BadRequest("Username is required");
        var token = _authService.GenerateToken(username);

        return Ok(new { Token = token });
    }
}