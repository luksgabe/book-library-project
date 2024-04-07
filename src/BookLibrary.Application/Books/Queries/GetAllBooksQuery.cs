using BookLibrary.Application.DataTransferObjects;
using BookLibrary.Application.Interfaces.Mediator;

namespace BookLibrary.Application.Books.Queries
{
    public class GetAllBooksQuery : BookQuery, IQuery<IEnumerable<BookDto>>
    {
    }
}
