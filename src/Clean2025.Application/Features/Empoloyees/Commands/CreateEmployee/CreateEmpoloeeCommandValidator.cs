using FluentValidation;

namespace Clean2025.Application.Features.Empoloyees.Commands.CreateEmployee
{
    public sealed class CreateEmpoloeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmpoloeeCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
            .MaximumLength(50).WithMessage("First name must be less than 50 characters")
            .MinimumLength(3).WithMessage("First name must be at least 3 characters");
            
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
            .MaximumLength(50).WithMessage("Last name must be less than 50 characters")
            .MinimumLength(3).WithMessage("Last name must be at least 3 characters");
            
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Birth date is required");
            RuleFor(x => x.PersonalInfo.TCNo)
                .NotEmpty().WithMessage("TC number is required")
                .Must(x => x != null && x.Value.Length == 11)
                .WithMessage("TC number must be exactly 11 digits");
            
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Salary is required");
        }
    }
}