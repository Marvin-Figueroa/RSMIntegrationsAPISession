using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RSMEnterpriseIntegrationsAPI.Domain.Models;

public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
{
  public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
  {
    builder.ToTable(nameof(SalesOrderHeader), "Sales");

    builder.HasKey(e => e.SalesOrderId);
    builder.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
    builder.Property(e => e.RevisionNumber);
    builder.Property(e => e.OrderDate).IsRequired();
    builder.Property(e => e.DueDate).IsRequired();
    builder.Property(e => e.ShipDate);
    builder.Property(e => e.Status).IsRequired();
    builder.Property(e => e.OnlineOrderFlag).IsRequired();
    builder.Property(e => e.SalesOrderNumber).HasComputedColumnSql();
    builder.Property(e => e.PurchaseOrderNumber);
    builder.Property(e => e.AccountNumber);
    builder.Property(e => e.CustomerId).HasColumnName("CustomerID").IsRequired();
    builder.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");
    builder.Property(e => e.TerritoryId).HasColumnName("TerritoryID");
    builder.Property(e => e.BillToAddressId).HasColumnName("BillToAddressID").IsRequired();
    builder.Property(e => e.ShipToAddressId).HasColumnName("ShipToAddressID").IsRequired();
    builder.Property(e => e.ShipMethodId).HasColumnName("ShipMethodID").IsRequired();
    builder.Property(e => e.CreditCardId).HasColumnName("CreditCardID");
    builder.Property(e => e.CreditCardApprovalCode);
    builder.Property(e => e.CurrencyRateId).HasColumnName("CurrencyRateID");
    builder.Property(e => e.SubTotal).IsRequired();
    builder.Property(e => e.TaxAmt).IsRequired();
    builder.Property(e => e.Freight).IsRequired();
    builder.Property(e => e.TotalDue).HasComputedColumnSql();
    builder.Property(e => e.Comment);
    builder.Property(e => e.Rowguid).HasComputedColumnSql().HasColumnName("rowguid");
    builder.Property(e => e.ModifiedDate).IsRequired();
  }
}
