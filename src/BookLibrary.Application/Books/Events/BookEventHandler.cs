using BookLibrary.Domain.Interfaces.SeedWork;
using MediatR;

namespace BookLibrary.Application.Books.Events
{
    public class BookEventHandler : INotificationHandler<BookRegisterEvent>
    {
        public Task Handle(BookRegisterEvent @event, CancellationToken cancellationToken)
        {
            /*It's could be used as external service trigger such as integration with another api, messageBroker, 
              maybe to save the datas in a no-sql like MongoDB or ElasticSearch, i just made this method to give an example... 
            */
            return Task.CompletedTask;
        }
    }
}
