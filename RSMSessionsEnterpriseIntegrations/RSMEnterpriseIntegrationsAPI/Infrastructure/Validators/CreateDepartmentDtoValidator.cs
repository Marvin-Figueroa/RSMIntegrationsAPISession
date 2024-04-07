using FluentValidation;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;

public class CreateDepartmentDtoValidator : AbstractValidator<CreateDepartmentDto>
{
  public CreateDepartmentDtoValidator()
  {
    RuleFor(dto => dto.Name)
        .NotEmpty().WithMessage("Name is required.")
        .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

    RuleFor(dto => dto.GroupName)
        .NotEmpty().WithMessage("GroupName is required.")
        .MaximumLength(100).WithMessage("GroupName cannot exceed 100 characters.");
  }
}
