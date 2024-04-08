namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{

  public class UpdateSalesOrderHeaderDto
  {
    /// Primary key.
    public int SalesOrderId { get; set; }

    /// Date the order is due to the customer.
    public DateTime? DueDate { get; set; }

    /// Date the order was shipped to the customer.
    public DateTime? ShipDate { get; set; }

    /// Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled
    public byte? Status { get; set; }

    /// Tax amount.
    public decimal? TaxAmt { get; set; }

    /// Shipping cost.
    public decimal? Freight { get; set; }

    /// Sales representative comments.
    public string? Comment { get; set; }
  }

}