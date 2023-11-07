using UseCases.Interfaces;

namespace UseCases.Offices.Commands
{
    public record DeleteOfficeCommand(Guid officeId) : ICommand;
}
