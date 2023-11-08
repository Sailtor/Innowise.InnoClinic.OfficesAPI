namespace Infrastructure.Persistence.MongoDb
{
    public interface IOfficesAPIDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string OfficesCollectionName { get; set; }
    }
}
