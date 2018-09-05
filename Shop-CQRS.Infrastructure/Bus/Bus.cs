using System.Threading.Tasks;
using MediatR;

namespace Shop_CQRS.Infrastructure.Bus
{
    public class Bus : IBus
    {
        private readonly IMediator mediator;

        public Bus(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<TResponse> Send<TCommand, TResponse>(TCommand command) where TCommand : IRequest<TResponse> 
            => await mediator.Send(command);
    }
}
