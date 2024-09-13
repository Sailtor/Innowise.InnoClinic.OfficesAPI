namespace Core.Entities
{
    public class Office
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int OfficeNumber { get; set; }
        public string RegistryPhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public Guid PhotoId { get; set; }
    }
}
