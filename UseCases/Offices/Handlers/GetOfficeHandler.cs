using AutoMapper;
using Core.Exceptions;
using Core.Repositories;
using UseCases.Infrastructure.Dtos.OfficeDto;
using UseCases.Interfaces;
using UseCases.Offices.Queries;

namespace UseCases.Handlers.Offices
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
            var office = await _repositoryManager.OfficeRepository.GetByIdAsync(request.officeId, cancellationToken);
            if (office is null)
            {
                throw new OfficeNotFoundException(request.officeId);
            }
            return _mapper.Map<OfficeForResponseDto>(office);
        }
    }
}
