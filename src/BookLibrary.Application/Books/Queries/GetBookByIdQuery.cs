using BookLibrary.Application.DataTransferObjects;
using BookLibrary.Application.Interfaces.Mediator;

namespace BookLibrary.Application.Books.Queries
{
    public class GetBookByIdQuery : BookQuery, IQuery<BookDto>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
