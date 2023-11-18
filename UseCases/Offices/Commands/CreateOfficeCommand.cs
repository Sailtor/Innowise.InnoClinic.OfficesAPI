using UseCases.Infrastructure.Dtos.OfficeDto;
using UseCases.Interfaces;

namespace UseCases.Offices.Commands
{
    public record CreateOfficeCommand(OfficeForCreationDto OfficeForCreation) : ICommand<OfficeForResponseDto>;
}
