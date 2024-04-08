namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{

  public class GetSalesOrderHeaderDto
  {
    /// Primary key.
    public int SalesOrderId { get; set; }

    /// Incremental number to track changes to the sales order over time.
    public byte RevisionNumber { get; set; }

    /// Dates the sales order was created.
    public DateTime OrderDate { get; set; } = DateTime.Now;

    /// Date the order is due to the customer.
    public DateTime DueDate { get; set; }

    /// Date the order was shipped to the customer.
    public DateTime? ShipDate { get; set; }

    /// Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled
    public byte Status { get; set; }

    /// 0 = Order placed by sales person. 1 = Order placed online by customer.
    public bool OnlineOrderFlag { get; set; }

    /// Unique sales order identification number.
    public string? SalesOrderNumber { get; set; }

    /// Customer purchase order number reference. 
    public string? PurchaseOrderNumber { get; set; }

    /// Customer identification number. Foreign key to Customer.BusinessEntityID.
    public int CustomerId { get; set; }

    /// Sales person who created the sales order. Foreign key to SalesPerson.BusinessEntityID.
    public int? SalesPersonId { get; set; }

    /// Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.
    public int? TerritoryId { get; set; }

    /// Customer billing address. Foreign key to Address.AddressID.
    public int BillToAddressId { get; set; }

    /// Customer shipping address. Foreign key to Address.AddressID.
    public int ShipToAddressId { get; set; }

    /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
    public int ShipMethodId { get; set; }

    /// Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.
    public decimal SubTotal { get; set; }

    /// Tax amount.
    public decimal TaxAmt { get; set; }

    /// Shipping cost.
    public decimal Freight { get; set; }

    /// Total due from customer. Computed as Subtotal + TaxAmt + Freight.
    public decimal? TotalDue { get; set; }

    /// Sales representative comments.
    public string? Comment { get; set; }
  }

}