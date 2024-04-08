namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{

  public class CreateSalesOrderHeaderDto
  {
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

    /// Customer purchase order number reference. 
    public string? PurchaseOrderNumber { get; set; }

    /// Financial accounting number reference.
    public string? AccountNumber { get; set; }

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

    /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
    public int? CreditCardId { get; set; }

    /// Approval code provided by the credit card company.
    public string? CreditCardApprovalCode { get; set; }

    /// Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.
    public int? CurrencyRateId { get; set; }

    /// Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.
    public decimal SubTotal { get; set; }

    /// Tax amount.
    public decimal TaxAmt { get; set; }

    /// Shipping cost.
    public decimal Freight { get; set; }

    /// Sales representative comments.
    public string? Comment { get; set; }
  }

}