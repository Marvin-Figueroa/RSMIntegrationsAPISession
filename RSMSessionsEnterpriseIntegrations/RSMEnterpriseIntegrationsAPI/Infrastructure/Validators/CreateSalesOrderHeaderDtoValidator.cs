using FluentValidation;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;

public class CreateSalesOrderHeaderDtoValidator : AbstractValidator<CreateSalesOrderHeaderDto>
{
  public CreateSalesOrderHeaderDtoValidator()
  {
    RuleFor(dto => dto.OrderDate).NotEmpty().WithMessage("Order date is required.");
    RuleFor(dto => dto.DueDate).NotEmpty().WithMessage("Due date is required.");
    RuleFor(dto => dto.Status).NotEmpty().WithMessage("Status is required.");
    RuleFor(dto => dto.OnlineOrderFlag).NotNull().WithMessage("Online order flag is required.");
    RuleFor(dto => dto.CustomerId).NotEmpty().WithMessage("Customer ID is required.");
    RuleFor(dto => dto.BillToAddressId).NotEmpty().WithMessage("Bill to address ID is required.");
    RuleFor(dto => dto.ShipToAddressId).NotEmpty().WithMessage("Ship to address ID is required.");
    RuleFor(dto => dto.ShipMethodId).NotEmpty().WithMessage("Ship method ID is required.");
    RuleFor(dto => dto.SubTotal).NotEmpty().WithMessage("Subtotal is required.");
    RuleFor(dto => dto.TaxAmt).NotEmpty().WithMessage("Tax amount is required.");
    RuleFor(dto => dto.Freight).NotEmpty().WithMessage("Freight amount is required.");
  }
}
