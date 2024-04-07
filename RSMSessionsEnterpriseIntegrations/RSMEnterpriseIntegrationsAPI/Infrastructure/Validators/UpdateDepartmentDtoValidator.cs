using FluentValidation;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;

public class UpdateDepartmentDtoValidator : AbstractValidator<UpdateDepartmentDto>
{
  public UpdateDepartmentDtoValidator()
  {
    RuleFor(dto => dto.DepartmentId)
        .NotEmpty().WithMessage("DepartmentId is required.")
        .GreaterThan((short)0).WithMessage("DepartmentId must be greater than 0.");

    RuleFor(dto => dto.Name)
        .NotEmpty().WithMessage("Name is required.")
        .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

    RuleFor(dto => dto.GroupName)
        .NotEmpty().WithMessage("GroupName is required.")
        .MaximumLength(100).WithMessage("GroupName cannot exceed 100 characters.");
  }
}
