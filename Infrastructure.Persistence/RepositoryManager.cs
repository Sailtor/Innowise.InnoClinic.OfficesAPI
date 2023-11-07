using Core.Repositories;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IOfficeRepository> _lazyOfficeRepository;


        public RepositoryManager(DapperContext dbContext)
        {
            _lazyOfficeRepository = new Lazy<IOfficeRepository>(() => new OfficeRepository(dbContext));
        }

        public IOfficeRepository OfficeRepository => _lazyOfficeRepository.Value;
    }
}
