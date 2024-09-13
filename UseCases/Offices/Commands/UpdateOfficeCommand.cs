using UseCases.Infrastructure.Dtos.OfficeDto;
using UseCases.Interfaces;

namespace UseCases.Offices.Commands
{
    public record UpdateOfficeCommand(Guid OfficeId, OfficeForUpdateDto OfficeForUpdate) : ICommand;
}
