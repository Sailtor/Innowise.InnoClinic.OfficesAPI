using AutoMapper;
using Core.Exceptions;
using Core.RepositoryInterfaces;
using UseCases.Interfaces;
using UseCases.Offices.Commands;

namespace UseCases.Offices.Handlers
{
    public class UpdateOfficeHandler : ICommandHandler<UpdateOfficeCommand>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateOfficeHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = await _repositoryManager.OfficeRepository.GetByIdAsync(request.OfficeId, cancellationToken);
            if (office is null)
            {
                throw new OfficeNotFoundException(request.OfficeId);
            }
            _mapper.Map(request.OfficeForUpdate, office);
            _repositoryManager.OfficeRepository.Update(office);
        }
    }
}
