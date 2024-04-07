using BookLibrary.Domain.Interfaces.SeedWork;
using MediatR;

namespace BookLibrary.Application.Mediator
{
    public abstract class Event : Message, IEvent, INotification
    {
        public DateTime Timestamp { get; private set; }
        protected Event()
        {
            Timestamp = DateTime.Now;
        }

    }
}
