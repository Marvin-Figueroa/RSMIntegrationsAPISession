using FluentValidation;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;

public class CreateProductCategoryDtoValidator : AbstractValidator<CreateProductCategoryDto>
{
  public CreateProductCategoryDtoValidator()
  {
    RuleFor(dto => dto.Name)
        .NotEmpty().WithMessage("Name is required.")
        .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
  }
}