namespace UseCases.Infrastructure.FluentValidation
{
    internal class ValidationMethods
    {
        internal static bool ValidateGuid(Guid? unvalidatedGuid)
        {
            if (unvalidatedGuid != Guid.Empty)
            {
                if (Guid.TryParse(unvalidatedGuid.ToString(), out _))
                {
                    return true;
                }
            }
            return false;
        }

        //Duct tape for not nullable guids
        internal static bool ValidateGuid(Guid unvalidatedGuid)
        {
            if (unvalidatedGuid != Guid.Empty)
            {
                if (Guid.TryParse(unvalidatedGuid.ToString(), out _))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
