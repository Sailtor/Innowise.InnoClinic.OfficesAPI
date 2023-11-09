using FluentValidation;
using System.Text.RegularExpressions;
using UseCases.Infrastructure.Dtos.OfficeDto;

namespace UseCases.Infrastructure.FluentValidation.Validators.CreateDto
{
    public class OfficeCreationDtoValidator : AbstractValidator<OfficeForCreationDto>
    {
        public OfficeCreationDtoValidator()
        {
            RuleFor(p => p.City).NotNull().WithMessage("City can't be null")
                .Length(2, 1024).WithMessage("City must be from 2 to 1024 characters long")
                .WithErrorCode("Invalid city name");

            RuleFor(p => p.Street).NotNull().WithMessage("Street can't be null")
                .Length(2, 1024).WithMessage("Street must be from 2 to 1024 characters long")
                .WithErrorCode("Invalid street name");

            RuleFor(p => p.HouseNumber).NotNull().WithMessage("House number can't be null")
                .InclusiveBetween(1, 2048).WithMessage("House number must be between 1 and 2048")
                .WithErrorCode("Invalid house number");

            RuleFor(p => p.OfficeNumber).NotNull().WithMessage("Office number can't be null")
                .InclusiveBetween(1, 2048).WithMessage("Office number must be between 1 and 2048")
                .WithErrorCode("Invalid service price");

            RuleFor(p => p.RegistryPhoneNumber).NotNull().WithMessage("Registry phone number can't be null")
                .Matches(new Regex(RegexStrings.PhoneRegex)).WithMessage("Registry phone number must be a valid phone number")
                .WithErrorCode("Invalid registry phone number");

            RuleFor(s => s.IsActive).NotNull().WithMessage("Office status can't be null")
                .WithErrorCode("Invalid office status");

            RuleFor(p => p.PhotoId).NotNull().WithMessage("Photo id can't be null")
                .Must(ValidationMethods.ValidateGuid).WithMessage("Photo id must be a valid guid")
                .WithErrorCode("Invalid office Id");
        }
    }
}
