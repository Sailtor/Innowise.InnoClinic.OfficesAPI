using Core.RepositoryInterfaces;
using Infrastructure.Persistence.MongoDb.Configurations;
using Infrastructure.Persistence.MongoDb.Repositories;

namespace Infrastructure.Persistence.MongoDb
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IOfficeRepository> _lazyOfficeRepository;

        public RepositoryManager(IOfficesAPIDbSettings settings)
        {
            _lazyOfficeRepository = new Lazy<IOfficeRepository>(() => new OfficeRepository(settings));
        }

        public IOfficeRepository OfficeRepository => _lazyOfficeRepository.Value;
    }
}
