using System.Threading.Tasks;
using MediatR;

namespace Shop_CQRS.Infrastructure.Bus
{
    public interface IBus
    {
        Task<TResponse> Send<TCommand, TResponse>(TCommand command) where TCommand : IRequest<TResponse>;
    }
}
