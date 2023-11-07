using UseCases.Infrastructure.Dtos.OfficeDto;
using UseCases.Interfaces;

namespace UseCases.Offices.Commands
{
    public record UpdateOfficeCommand(Guid officeId, OfficeForUpdateDto officeForUpdate) : ICommand;
}
