using UseCases.Infrastructure.Dtos.OfficeDto;
using UseCases.Interfaces;

namespace UseCases.Offices.Queries
{
    public record GetOfficeQuery(Guid officeId) : IQuery<OfficeForResponseDto>;
}
