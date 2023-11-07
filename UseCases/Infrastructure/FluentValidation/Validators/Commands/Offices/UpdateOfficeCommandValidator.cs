using FluentValidation;
using UseCases.Infrastructure.FluentValidation.Validators.UpdateDto;
using UseCases.Offices.Commands;

namespace UseCases.Infrastructure.FluentValidation.Validators.Commands.Offices
{
    public class UpdateOfficeCommandValidator : AbstractValidator<UpdateOfficeCommand>
    {
        public UpdateOfficeCommandValidator()
        {
            RuleFor(p => p.officeId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid office ID");
            RuleFor(p => p.officeForUpdate).NotNull().SetValidator(new OfficeUpdateDtoValidator()).WithErrorCode("Invalid office");
        }
    }
}
