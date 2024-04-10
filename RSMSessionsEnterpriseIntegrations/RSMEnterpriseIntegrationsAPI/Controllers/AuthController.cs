namespace RSMEnterpriseIntegrationsAPI.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using RSMEnterpriseIntegrationsAPI.Application.DTOs;
  using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;

  [Route("api/auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
      _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
      return Ok(await _service.Register(dto));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
      return Ok(await _service.Login(loginDto));
    }

  }
}
