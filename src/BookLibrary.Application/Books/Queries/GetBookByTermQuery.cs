using BookLibrary.Application.DataTransferObjects;
using BookLibrary.Application.Interfaces.Mediator;

namespace BookLibrary.Application.Books.Queries
{
    public class GetBookByTermQuery : BookQuery, IQuery<IEnumerable<BookDto>>
    {
        public string SearchTerm { get; private set; }
        public GetBookByTermQuery(string searchTerm)
        {
            this.SearchTerm = searchTerm;
        }
    }
}
