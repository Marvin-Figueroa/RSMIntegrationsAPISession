namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
  using Microsoft.EntityFrameworkCore;
  using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
  using RSMEnterpriseIntegrationsAPI.Domain.Models;

  using System.Threading.Tasks;

  public class AuthRepository : IAuthRepository
  {
    private readonly AdvWorksAuthDbContext _context;
    public AuthRepository(AdvWorksAuthDbContext context)
    {
      _context = context;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<int> Register(User user)
    {
      await _context.AddAsync(user);

      return await _context.SaveChangesAsync();
    }



  }
}