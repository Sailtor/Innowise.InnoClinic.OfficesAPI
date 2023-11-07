using FluentValidation;
using System.Text.RegularExpressions;
using UseCases.Infrastructure.Dtos.OfficeDto;

namespace UseCases.Infrastructure.FluentValidation.Validators.CreateDto
{
    public class OfficeCreationDtoValidator : AbstractValidator<OfficeForCreationDto>
    {
        public OfficeCreationDtoValidator()
        {
            RuleFor(p => p.City).NotNull().NotEmpty().Length(2, 1024).WithErrorCode("Invalid city name");
            RuleFor(p => p.Street).NotNull().NotEmpty().Length(2, 1024).WithErrorCode("Invalid street name");
            RuleFor(p => p.HouseNumber).NotNull().InclusiveBetween(1, 2048).WithErrorCode("Invalid house number");
            RuleFor(p => p.OfficeNumber).NotNull().InclusiveBetween(1, 2048).WithErrorCode("Invalid service price");
            RuleFor(p => p.RegistryPhoneNumber).NotNull().Length(2, 1024).Matches(new Regex(RegexStrings.PhoneRegex)).WithErrorCode("Invalid registry phone number");
            RuleFor(s => s.IsActive).NotNull().WithErrorCode("Invalid office status");
            RuleFor(p => p.PhotoId).NotNull().Must(ValidationMethods.ValidateGuid).WithErrorCode("Invalid office Id");
        }
    }
}
