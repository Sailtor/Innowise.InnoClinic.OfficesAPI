using MediatR;

namespace UseCases.Interfaces
{
    public interface ICommand<out TResponse> : IBaseCommand, IRequest<TResponse>
    {
    }
    public interface ICommand : IBaseCommand, IRequest
    {
    }
}
