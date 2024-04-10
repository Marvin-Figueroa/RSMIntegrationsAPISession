using FluentValidation;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
  public RegisterDtoValidator()
  {
    RuleFor(dto => dto.Name)
        .NotEmpty().WithMessage("Name is required.")
        .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

    RuleFor(dto => dto.Email)
        .NotEmpty().WithMessage("Email is required.")
        .EmailAddress().WithMessage("Email must be valid.")
        .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

    RuleFor(dto => dto.Password)
        .NotEmpty().WithMessage("Password is required.")
        .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
        .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.");
  }
}