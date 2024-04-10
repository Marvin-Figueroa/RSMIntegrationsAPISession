namespace RSMEnterpriseIntegrationsAPI.Infrastructure
{
  using Microsoft.EntityFrameworkCore;

  using RSMEnterpriseIntegrationsAPI.Domain.Models;

  using System.Reflection;

  public class AdvWorksAuthDbContext : DbContext
  {
    public AdvWorksAuthDbContext()
    {
    }

    public AdvWorksAuthDbContext(DbContextOptions<AdvWorksAuthDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

  }
}
