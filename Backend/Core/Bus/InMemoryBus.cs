using System.Threading.Tasks;
using Backend.Core.Commands;
using Backend.Core.Events;
using MediatR;

namespace Backend.Core.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            _mediator.Send(command);
            return Task.CompletedTask;

        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            //if (!@event.MessageType.Equals("DomainNotification")) {_eventStore?.Save(@event);}

             _mediator.Publish(@event);
            return Task.CompletedTask;
        }
    }
}