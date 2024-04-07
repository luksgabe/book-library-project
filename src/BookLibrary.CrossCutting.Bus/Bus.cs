using BookLibrary.Application.Interfaces.Mediator;
using BookLibrary.Application.Mediator;
using FluentValidation.Results;
using MediatR;


namespace BookLibrary.CrossCutting.Bus
{
    public class Bus : IMediatorHandler
    {

        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;
        public Bus(IMediator mediator, IEventStore eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> query)
        {
            return await _mediator.Send(query);
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            await _mediator.Publish(@event);
        }

    }
}