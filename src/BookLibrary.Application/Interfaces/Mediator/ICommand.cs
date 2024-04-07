using MediatR;

namespace BookLibrary.Application.Interfaces.Mediator
{
    public interface ICommand : IRequest
    {
        long Id { get; }
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        long Id { get; }
    }
}
