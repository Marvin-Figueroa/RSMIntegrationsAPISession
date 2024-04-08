using FluentValidation;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
  public UpdateProductDtoValidator()
  {
    RuleFor(dto => dto.ProductId).NotEmpty().WithMessage("ProductId is required.");
    RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required.");
    RuleFor(dto => dto.ProductNumber).NotEmpty().WithMessage("ProductNumber is required.");
    RuleFor(dto => dto.SafetyStockLevel).GreaterThan((short)0).WithMessage("SafetyStockLevel must be greater than 0.");
    RuleFor(dto => dto.ReorderPoint).GreaterThan((short)0).WithMessage("ReorderPoint must be greater than 0.");
    RuleFor(dto => dto.StandardCost).GreaterThanOrEqualTo(0).WithMessage("StandardCost must be greater than or equal to 0.");
    RuleFor(dto => dto.ListPrice).GreaterThanOrEqualTo(0).WithMessage("ListPrice must be greater than or equal to 0.");
    RuleFor(dto => dto.DaysToManufacture).GreaterThan(0).WithMessage("DaysToManufacture must be greater than 0.");
    RuleFor(dto => dto.SellStartDate).NotEmpty().WithMessage("SellStartDate is required.");
    RuleFor(dto => dto.SellEndDate)
        .Null()
        .When(dto => dto.SellEndDate.HasValue)
        .WithMessage("SellEndDate must be null if set.")
        .GreaterThan(dto => dto.SellStartDate)
        .When(dto => dto.SellEndDate.HasValue)
        .WithMessage("SellEndDate must be greater than SellStartDate if set.");
    RuleFor(dto => dto.DiscontinuedDate)
        .Null()
        .When(dto => dto.DiscontinuedDate.HasValue)
        .WithMessage("DiscontinuedDate must be null if set.")
        .GreaterThan(dto => dto.SellStartDate)
        .When(dto => dto.DiscontinuedDate.HasValue)
        .WithMessage("DiscontinuedDate must be greater than SellStartDate if set.")
        .LessThanOrEqualTo(DateTime.Now)
        .When(dto => dto.DiscontinuedDate.HasValue)
        .WithMessage("DiscontinuedDate must be less than or equal to current date if set.");
  }
}
