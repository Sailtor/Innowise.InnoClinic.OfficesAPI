using FluentValidation;
using UseCases.Offices.Commands;

namespace UseCases.Infrastructure.FluentValidation.Validators.Commands.Offices
{
    public class DeleteOfficeCommandValidator : AbstractValidator<DeleteOfficeCommand>
    {
        public DeleteOfficeCommandValidator()
        {
            RuleFor(p => p.officeId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid office ID");
        }
    }
}
