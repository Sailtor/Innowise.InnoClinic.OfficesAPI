using Core.Exceptions;
using Core.RepositoryInterfaces;
using UseCases.Interfaces;
using UseCases.Offices.Commands;

namespace UseCases.Offices.Handlers
{
    public class DeleteOfficeHandler : ICommandHandler<DeleteOfficeCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteOfficeHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Handle(DeleteOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = await _repositoryManager.OfficeRepository.GetByIdAsync(request.OfficeId, cancellationToken);
            if (office is null)
            {
                throw new OfficeNotFoundException(request.OfficeId);
            }
            _repositoryManager.OfficeRepository.Remove(office);
        }
    }
}
