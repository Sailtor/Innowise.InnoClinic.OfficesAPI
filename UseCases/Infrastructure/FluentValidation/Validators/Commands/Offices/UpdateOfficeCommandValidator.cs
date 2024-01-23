using FluentValidation;
using UseCases.Infrastructure.FluentValidation.Validators.UpdateDto;
using UseCases.Offices.Commands;

namespace UseCases.Infrastructure.FluentValidation.Validators.Commands.Offices
{
    public class UpdateOfficeCommandValidator : AbstractValidator<UpdateOfficeCommand>
    {
        public UpdateOfficeCommandValidator()
        {
            RuleFor(p => p.OfficeId).NotNull().WithMessage("Office id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Office id must be a valid guid")
                .WithErrorCode("Invalid office ID");

            RuleFor(p => p.OfficeForUpdate).NotNull().WithMessage("Office can't be null")
                .SetValidator(new OfficeUpdateDtoValidator())
                .WithErrorCode("Invalid office");
        }
    }
}
