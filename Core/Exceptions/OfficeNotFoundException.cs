namespace Core.Exceptions
{
    public sealed class OfficeNotFoundException : NotFoundException
    {
        public OfficeNotFoundException(Guid serviceId)
            : base($"The office with the identifier {serviceId} was not found.")
        {
        }
    }
}
