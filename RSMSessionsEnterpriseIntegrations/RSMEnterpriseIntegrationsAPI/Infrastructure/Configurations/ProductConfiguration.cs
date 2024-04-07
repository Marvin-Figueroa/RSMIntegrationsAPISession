namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;

  using RSMEnterpriseIntegrationsAPI.Domain.Models;

  public class ProductConfiguration : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.ToTable(nameof(Product), "Production");

      builder.HasKey(e => e.ProductId);
      builder.Property(e => e.ProductId).HasColumnName("ProductID");
      builder.Property(e => e.Name).IsRequired();
      builder.Property(e => e.ProductNumber).IsRequired();
      builder.Property(e => e.MakeFlag);
      builder.Property(e => e.FinishedGoodsFlag);
      builder.Property(e => e.Color);
      builder.Property(e => e.SafetyStockLevel).IsRequired();
      builder.Property(e => e.ReorderPoint).IsRequired();
      builder.Property(e => e.StandardCost).IsRequired();
      builder.Property(e => e.ListPrice).IsRequired();
      builder.Property(e => e.Size);
      builder.Property(e => e.SizeUnitMeasureCode);
      builder.Property(e => e.WeightUnitMeasureCode);
      builder.Property(e => e.Weight);
      builder.Property(e => e.DaysToManufacture).IsRequired();
      builder.Property(e => e.ProductLine);
      builder.Property(e => e.Class);
      builder.Property(e => e.Style);
      builder.Property(e => e.ProductSubcategoryId);
      builder.Property(e => e.ProductModelId);
      builder.Property(e => e.SellStartDate).IsRequired();
      builder.Property(e => e.SellEndDate);
      builder.Property(e => e.DiscontinuedDate);
      builder.Property(e => e.Rowguid).HasColumnName("rowguid");
      builder.Property(e => e.ModifiedDate);


    }
  }
}