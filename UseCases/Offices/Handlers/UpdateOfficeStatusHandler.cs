using Core.Exceptions;
using Core.RepositoryInterfaces;
using Infrastructure.Shared;
using MassTransit;
using UseCases.Interfaces;
using UseCases.Offices.Commands;

namespace UseCases.Offices.Handlers
{
    public class UpdateOfficeStatusHandler : ICommandHandler<UpdateOfficeStatusCommand>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IPublishEndpoint _publishEndpoint;
        public UpdateOfficeStatusHandler(IRepositoryManager repositoryManager, IPublishEndpoint publishEndpoint)
        {
            _repositoryManager = repositoryManager;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(UpdateOfficeStatusCommand request, CancellationToken cancellationToken)
        {
            var office = await _repositoryManager.OfficeRepository.GetByIdAsync(request.OfficeId, cancellationToken);
            if (office is null)
            {
                throw new OfficeNotFoundException(request.OfficeId);
            }
            office.IsActive = request.IsActive;
            _repositoryManager.OfficeRepository.Update(office);

            await _publishEndpoint.Publish<OfficeStatusChanged>(new
            {
                Id = office.Id,
                IsActive = request.IsActive
            }, cancellationToken);
        }
    }
}
