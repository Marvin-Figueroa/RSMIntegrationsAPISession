using FluentValidation;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;

public class UpdateSalesOrderHeaderDtoValidator : AbstractValidator<UpdateSalesOrderHeaderDto>
{
  public UpdateSalesOrderHeaderDtoValidator()
  {
    RuleFor(dto => dto.SalesOrderId).NotEmpty().WithMessage("Sales order ID is required.");
  }
}
