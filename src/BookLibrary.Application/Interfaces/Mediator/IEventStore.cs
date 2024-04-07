using BookLibrary.Application.Mediator;

namespace BookLibrary.Application.Interfaces.Mediator
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
