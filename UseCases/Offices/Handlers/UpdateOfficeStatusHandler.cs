using Core.Exceptions;
using Core.Repositories;
using UseCases.Interfaces;
using UseCases.Offices.Commands;

namespace UseCases.Offices.Handlers
{
    public class UpdateOfficeStatusHandler : ICommandHandler<UpdateOfficeStatusCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateOfficeStatusHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task Handle(UpdateOfficeStatusCommand request, CancellationToken cancellationToken)
        {
            var office = await _repositoryManager.OfficeRepository.GetByIdAsync(request.officeId, cancellationToken);
            if (office is null)
            {
                throw new OfficeNotFoundException(request.officeId);
            }
            office.IsActive = request.isActive;
            _repositoryManager.OfficeRepository.Update(office);

            /*
             TODO: send rabbitmq message to update doctor and receptionst statuses
             */
        }
    }
}
