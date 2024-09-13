using AutoMapper;
using Core.RepositoryInterfaces;
using UseCases.Infrastructure.Dtos.OfficeDto;
using UseCases.Interfaces;
using UseCases.Offices.Queries;

namespace UseCases.Offices.Handlers
{
    public class GetOfficesHandler : IQueryHandler<GetOfficesQuery, IEnumerable<OfficeForResponseDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOfficesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OfficeForResponseDto>> Handle(GetOfficesQuery request, CancellationToken cancellationToken)
        {
            var offices = await _repositoryManager.OfficeRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<OfficeForResponseDto>>(offices);
        }
    }
}
