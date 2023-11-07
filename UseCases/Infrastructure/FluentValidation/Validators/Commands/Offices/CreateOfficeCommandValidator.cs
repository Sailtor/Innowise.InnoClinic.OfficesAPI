using FluentValidation;
using UseCases.Infrastructure.FluentValidation.Validators.CreateDto;
using UseCases.Offices.Commands;

namespace UseCases.Infrastructure.FluentValidation.Validators.Commands.Offices
{
    public class CreateOfficeCommandValidator : AbstractValidator<CreateOfficeCommand>
    {
        public CreateOfficeCommandValidator()
        {
            RuleFor(p => p.officeForCreation).NotNull().SetValidator(new OfficeCreationDtoValidator()).WithErrorCode("Invalid office");
        }
    }
}
