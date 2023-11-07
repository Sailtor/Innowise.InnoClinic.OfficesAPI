namespace Core.Exceptions
{
    public sealed class OfficeNotFoundException : NotFoundException
    {
        public OfficeNotFoundException(Guid officeId)
            : base($"The office with the identifier {officeId} was not found.")
        {
        }
    }
}
