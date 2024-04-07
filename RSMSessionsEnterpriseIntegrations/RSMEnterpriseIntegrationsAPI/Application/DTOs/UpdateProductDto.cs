namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
  public class UpdateProductDto
  {
    /// Primary key for Product records.
    public int ProductId { get; set; }

    /// Name of the product.
    public string Name { get; set; } = null!;

    /// Unique product identification number.
    public string ProductNumber { get; set; } = null!;

    /// Product color.
    public string? Color { get; set; }

    /// Minimum inventory quantity. 
    public short SafetyStockLevel { get; set; }

    /// Inventory level that triggers a purchase order or work order. 
    public short ReorderPoint { get; set; }

    /// Standard cost of the product.
    public decimal StandardCost { get; set; }

    /// Selling price.
    public decimal ListPrice { get; set; }

    /// Product size.
    public string? Size { get; set; }

    /// Unit of measure for Size column.
    public string? SizeUnitMeasureCode { get; set; }

    /// Unit of measure for Weight column.
    public string? WeightUnitMeasureCode { get; set; }

    /// Product weight.
    public decimal? Weight { get; set; }

    /// Number of days required to manufacture the product.
    public int DaysToManufacture { get; set; }

    /// R = Road, M = Mountain, T = Touring, S = Standard
    public string? ProductLine { get; set; } = "S";

    /// H = High, M = Medium, L = Low
    public string? Class { get; set; } = "M";

    /// W = Womens, M = Mens, U = Universal
    public string? Style { get; set; } = "W";

    /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. 
    public int? ProductSubcategoryId { get; set; }

    /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
    public int? ProductModelId { get; set; }

    /// Date the product was available for sale.
    public DateTime SellStartDate { get; set; } = DateTime.Now;

    /// Date the product was no longer available for sale.
    public DateTime? SellEndDate { get; set; }

    /// Date the product was discontinued.
    public DateTime? DiscontinuedDate { get; set; }
  }
}