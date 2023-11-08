using Core.Entities;
using Core.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;

namespace Infrastructure.Persistence.MongoDb.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IMongoCollection<Office> _offices;
        public OfficeRepository(IOfficesAPIDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _offices = database.GetCollection<Office>(settings.OfficesCollectionName);
        }

        public async Task<IEnumerable<Office>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _offices.Find(s => true).ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<Office> GetByIdAsync(Guid officeId, CancellationToken cancellationToken = default)
        {
            return await _offices.Find(o => o.Id == officeId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task<Office> AddAsync(Office office, CancellationToken cancellationToken)
        {
            await _offices.InsertOneAsync(office, cancellationToken: cancellationToken);
            return office;
        }
        public void Update(Office office)
        {
            _offices.ReplaceOne(o => o.Id == office.Id, office);
        }

        public void Remove(Office office)
        {
            _offices.DeleteOne(o => o.Id == office.Id);
        }
    }
}
