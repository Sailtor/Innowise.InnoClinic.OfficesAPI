namespace UseCases.Infrastructure.Dtos.OfficeDto
{
    public class OfficeForUpdateDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int OfficeNumber { get; set; }
        public string RegistryPhoneNumber { get; set; }
        public Guid PhotoId { get; set; }
    }
}
