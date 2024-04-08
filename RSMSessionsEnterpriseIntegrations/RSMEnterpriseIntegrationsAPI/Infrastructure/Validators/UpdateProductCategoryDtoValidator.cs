using FluentValidation;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;

public class UpdateProductCategoryDtoValidator : AbstractValidator<UpdateProductCategoryDto>
{
  public UpdateProductCategoryDtoValidator()
  {
    RuleFor(dto => dto.ProductCategoryId)
        .NotEmpty().WithMessage("DepartmentId is required.")
        .GreaterThan((short)0).WithMessage("DepartmentId must be greater than 0.");

    RuleFor(dto => dto.Name)
        .NotEmpty().WithMessage("Name is required.")
        .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
  }
}