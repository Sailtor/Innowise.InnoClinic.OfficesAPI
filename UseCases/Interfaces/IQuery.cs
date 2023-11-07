using MediatR;

namespace UseCases.Interfaces
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
