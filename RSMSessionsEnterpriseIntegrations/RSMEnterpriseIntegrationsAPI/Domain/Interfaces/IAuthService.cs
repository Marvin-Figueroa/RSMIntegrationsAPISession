namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
  using RSMEnterpriseIntegrationsAPI.Application.DTOs;

  public interface IAuthService
  {
    Task<AuthResponseDto> Register(RegisterDto registerDto);
    Task<AuthResponseDto> Login(LoginDto loginDto);
  }
}