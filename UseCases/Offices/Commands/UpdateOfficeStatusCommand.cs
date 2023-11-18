using UseCases.Interfaces;

namespace UseCases.Offices.Commands
{
    public record UpdateOfficeStatusCommand(Guid OfficeId, bool IsActive) : ICommand;
}
