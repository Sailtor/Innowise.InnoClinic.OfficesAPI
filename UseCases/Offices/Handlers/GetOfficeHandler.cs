using AutoMapper;
using Core.Exceptions;
using Core.RepositoryInterfaces;
using UseCases.Infrastructure.Dtos.OfficeDto;
using UseCases.Interfaces;
using UseCases.Offices.Queries;

namespace UseCases.Offices.Handlers
{
    public class GetOfficeHandler : IQueryHandler<GetOfficeQuery, OfficeForResponseDto>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOfficeHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<OfficeForResponseDto> Handle(GetOfficeQuery request, CancellationToken cancellationToken)
        {
            var office = await _repositoryManager.OfficeRepository.GetByIdAsync(request.OfficeId, cancellationToken);
            if (office is null)
            {
                throw new OfficeNotFoundException(request.OfficeId);
            }
            return _mapper.Map<OfficeForResponseDto>(office);
        }
    }
}
