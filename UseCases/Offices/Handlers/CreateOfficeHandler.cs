using AutoMapper;
using Core.Entities;
using Core.RepositoryInterfaces;
using UseCases.Infrastructure.Dtos.OfficeDto;
using UseCases.Interfaces;
using UseCases.Offices.Commands;

namespace UseCases.Offices.Handlers
{
    public class CreateOfficeHandler : ICommandHandler<CreateOfficeCommand, OfficeForResponseDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateOfficeHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<OfficeForResponseDto> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = _mapper.Map<Office>(request.officeForCreation);
            office = await _repositoryManager.OfficeRepository.AddAsync(office, cancellationToken);
            return _mapper.Map<OfficeForResponseDto>(office);
        }
    }
}
