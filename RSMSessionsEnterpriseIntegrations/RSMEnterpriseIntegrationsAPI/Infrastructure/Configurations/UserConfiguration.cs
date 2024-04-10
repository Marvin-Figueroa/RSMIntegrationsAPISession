namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;

  using RSMEnterpriseIntegrationsAPI.Domain.Models;

  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("Users");

      builder.HasKey(e => e.UserId);
      builder.Property(e => e.UserId).HasColumnName("UserId").ValueGeneratedOnAdd();
      builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
      builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
      builder.Property(e => e.Password).IsRequired().HasMaxLength(500);
      builder.Property(e => e.Role).IsRequired().HasMaxLength(20).HasDefaultValue("user");
    }
  }
}