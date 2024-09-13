using FluentValidation;
using UseCases.Offices.Commands;

namespace UseCases.Infrastructure.FluentValidation.Validators.Commands.Offices
{
    public class UpdateOfficeStatusCommandValidator : AbstractValidator<UpdateOfficeStatusCommand>
    {
        public UpdateOfficeStatusCommandValidator()
        {
            RuleFor(p => p.OfficeId).NotNull().WithMessage("Office id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Office id must be a valid guid")
                .WithErrorCode("Invalid office ID");

            RuleFor(p => p.IsActive).NotNull().WithMessage("Office status can't be null")
                .WithErrorCode("Invalid office status");
        }
    }
}
