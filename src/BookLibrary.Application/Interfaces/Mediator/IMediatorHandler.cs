using BookLibrary.Application.Mediator;
using FluentValidation.Results;
using MediatR;


namespace BookLibrary.Application.Interfaces.Mediator
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;

        Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> request);

        Task PublishEvent<T>(T @event) where T : Event;
    }
}
