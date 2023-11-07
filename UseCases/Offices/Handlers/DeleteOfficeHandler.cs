using Core.Exceptions;
using Core.Repositories;
using UseCases.Interfaces;
using UseCases.Offices.Commands;

namespace UseCases.Handlers.Offices
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
            var office = await _repositoryManager.OfficeRepository.GetByIdAsync(request.officeId, cancellationToken);
            if (office is null)
            {
                throw new OfficeNotFoundException(request.officeId);
            }
            _repositoryManager.OfficeRepository.Remove(office);
        }
    }
}
