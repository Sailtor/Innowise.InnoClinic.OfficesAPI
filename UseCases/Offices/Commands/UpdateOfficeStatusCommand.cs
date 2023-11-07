using UseCases.Interfaces;

namespace UseCases.Offices.Commands
{
    public record UpdateOfficeStatusCommand(Guid officeId, bool isActive) : ICommand;
}
