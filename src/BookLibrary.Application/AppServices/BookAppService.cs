using BookLibrary.Application.DataTransferObjects;
using BookLibrary.Application.Interfaces;
using BookLibrary.Domain.Interfaces.Repositories;

namespace BookLibrary.Application.AppServices
{
    public class BookAppService : IBookAppService
    {
        private readonly IBookRepository _bookRepository;


        public BookAppService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
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

        public async Task<IEnumerable<BookDto>> GetBooks()
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

        public async Task Create(BookDto bookDto)
        {
            throw new NotImplementedException();
        }
    }
}
