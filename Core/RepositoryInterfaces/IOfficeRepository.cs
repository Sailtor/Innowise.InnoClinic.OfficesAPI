using Core.Entities;

namespace Core.RepositoryInterfaces
{
    public interface IOfficeRepository
    {
        Task<IEnumerable<Office>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Office> GetByIdAsync(Guid officeId, CancellationToken cancellationToken = default);
        Task<Office> AddAsync(Office office, CancellationToken cancellationToken = default);
        void Update(Office office);
        void Remove(Office office);
    }
}
