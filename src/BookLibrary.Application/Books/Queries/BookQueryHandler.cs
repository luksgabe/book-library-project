using BookLibrary.Application.DataTransferObjects;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Interfaces.Repositories;
using MediatR;

namespace BookLibrary.Application.Books.Queries
{
    public class BookQueryHandler : 
        IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>,
        IRequestHandler<GetBookByTermQuery, IEnumerable<BookDto>>,
        IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;

        public BookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository= bookRepository;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(p => new BookDto
            {
                Type = p.Type,
                Category = p.Category,
                CopiesInUse= p.CopiesInUse,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Id = p.Id,
                Isbn= p.Isbn,
                TotalCopies = p.TotalCopies,
                Title = p.Title,
            }).ToList();
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Category = book.Category,
                CopiesInUse = book.CopiesInUse,
                FirstName = book.FirstName,
                LastName = book.LastName,
                Isbn = book.Isbn,
                TotalCopies = book.TotalCopies,
                Type = book.Type,
            };
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBookByTermQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Book> books = new List<Book>();
            var searchValue = request.SearchTerm;

            if (string.IsNullOrEmpty(searchValue))
                books = await _bookRepository.GetAllAsync();
            else
            {
                books = await _bookRepository
                .GetCustomData(p => p.Title.Contains(searchValue)
                    || p.FirstName.Contains(searchValue)
                    || p.LastName.Contains(searchValue)
                    || p.Type.Contains(searchValue)
                    || p.Category.Contains(searchValue)
                    || p.Isbn.Contains(searchValue)
                    || p.CopiesInUse.ToString().Contains(searchValue)
                    || p.TotalCopies.ToString().Contains(searchValue)
                    );
            }

            return books.Select(p => new BookDto
            {
                Type = p.Type,
                Category = p.Category,
                CopiesInUse= p.CopiesInUse,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Id = p.Id,
                Isbn= p.Isbn,
                TotalCopies = p.TotalCopies,
                Title = p.Title,
            }).ToList();
        }
    }
}
