namespace UseCases.Infrastructure.FluentValidation
{
    public static class RegexStrings
    {
        public const string PhoneRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
    }
}
