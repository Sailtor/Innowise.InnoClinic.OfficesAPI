using FluentValidation;
using UseCases.Offices.Commands;

namespace UseCases.Infrastructure.FluentValidation.Validators.Commands.Offices
{
    public class DeleteOfficeCommandValidator : AbstractValidator<DeleteOfficeCommand>
    {
        public DeleteOfficeCommandValidator()
        {
            RuleFor(p => p.officeId).NotNull().WithMessage("Office id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Office id must be a valid guid")
                .WithErrorCode("Invalid office ID");
        }
    }
}
