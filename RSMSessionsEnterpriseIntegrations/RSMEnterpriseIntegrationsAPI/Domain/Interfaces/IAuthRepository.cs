namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
  using RSMEnterpriseIntegrationsAPI.Domain.Models;

  public interface IAuthRepository
  {
    Task<int> Register(User user);
    Task<User?> GetUserByEmail(string email);
  }
}