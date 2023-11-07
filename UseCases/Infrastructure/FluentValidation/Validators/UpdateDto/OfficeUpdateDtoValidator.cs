using FluentValidation;
using System.Text.RegularExpressions;
using UseCases.Infrastructure.Dtos.OfficeDto;

namespace UseCases.Infrastructure.FluentValidation.Validators.UpdateDto
{
    public class OfficeUpdateDtoValidator : AbstractValidator<OfficeForUpdateDto>
    {
        public OfficeUpdateDtoValidator()
        {
            RuleFor(p => p.City).NotNull().NotEmpty().Length(2, 1024).WithErrorCode("Invalid city name");
            RuleFor(p => p.Street).NotNull().NotEmpty().Length(2, 1024).WithErrorCode("Invalid street name");
            RuleFor(p => p.HouseNumber).NotNull().InclusiveBetween(1, 2048).WithErrorCode("Invalid house number");
            RuleFor(p => p.OfficeNumber).NotNull().InclusiveBetween(1, 2048).WithErrorCode("Invalid service price");
            RuleFor(p => p.RegistryPhoneNumber).NotNull().Matches(new Regex(RegexStrings.PhoneRegex)).WithErrorCode("Invalid registry phone number");
            RuleFor(p => p.PhotoId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid office Id");
        }
    }
}
