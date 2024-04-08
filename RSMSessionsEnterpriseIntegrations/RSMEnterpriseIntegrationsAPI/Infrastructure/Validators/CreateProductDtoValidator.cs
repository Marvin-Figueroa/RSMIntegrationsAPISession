using FluentValidation;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
  public CreateProductDtoValidator()
  {
    RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required.");
    RuleFor(dto => dto.ProductNumber).NotEmpty().WithMessage("Product number is required.");
    RuleFor(dto => dto.SafetyStockLevel).GreaterThan((short)0).WithMessage("Safety stock level must be greater than 0.");
    RuleFor(dto => dto.ReorderPoint).GreaterThan((short)0).WithMessage("Reorder point must be greater than 0.");
    RuleFor(dto => dto.StandardCost).GreaterThanOrEqualTo(0).WithMessage("Standard cost must be greater than or equal to 0.");
    RuleFor(dto => dto.ListPrice).GreaterThanOrEqualTo(0).WithMessage("List price must be greater than or equal to 0.");
    RuleFor(dto => dto.DaysToManufacture).GreaterThan(0).WithMessage("Days to manufacture must be greater than 0.");
    RuleFor(dto => dto.SellStartDate).NotEmpty().WithMessage("Sell start date is required.");
    RuleFor(dto => dto.SellEndDate)
        .Null()
        .When(dto => dto.SellEndDate.HasValue)
        .WithMessage("Sell end date must be null if set.");
    RuleFor(dto => dto.DiscontinuedDate)
        .Null()
        .When(dto => dto.DiscontinuedDate.HasValue)
        .WithMessage("Discontinued date must be null if set.")
        .GreaterThan(dto => dto.SellStartDate)
        .When(dto => dto.DiscontinuedDate.HasValue)
        .WithMessage("Discontinued date must be greater than sell start date.");
  }
}
