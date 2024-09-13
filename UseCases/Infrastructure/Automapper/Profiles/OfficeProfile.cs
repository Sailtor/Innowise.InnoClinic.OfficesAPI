using AutoMapper;
using Core.Entities;
using UseCases.Infrastructure.Dtos.OfficeDto;

namespace UseCases.Infrastructure.Automapper.Profiles
{
    public sealed class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<OfficeForCreationDto, Office>();
            CreateMap<OfficeForUpdateDto, Office>();
            CreateMap<Office, OfficeForResponseDto>();
        }
    }

}
