namespace UseCases.Infrastructure.FluentValidation
{
    internal class ValidationMethods
    {
        internal static bool ValidateGuid(Guid unvalidatedGuid)
        {
            return Guid.TryParse(unvalidatedGuid.ToString(), out _);
        }
    }
}
