using MediatR;

namespace BookLibrary.Application.Interfaces.Mediator
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
