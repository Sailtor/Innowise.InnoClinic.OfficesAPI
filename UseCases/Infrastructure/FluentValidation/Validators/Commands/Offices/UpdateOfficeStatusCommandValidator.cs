using FluentValidation;
using UseCases.Offices.Commands;

namespace UseCases.Infrastructure.FluentValidation.Validators.Commands.Offices
{
    public class UpdateOfficeStatusCommandValidator : AbstractValidator<UpdateOfficeStatusCommand>
    {
        public UpdateOfficeStatusCommandValidator()
        {
            RuleFor(p => p.officeId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid office ID");
            RuleFor(p => p.isActive).NotNull().WithErrorCode("Invalid office status");
        }
    }
}
