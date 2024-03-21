using BookLibrary.Application.DataTransferObjects;

namespace BookLibrary.Application.Interfaces
{
    public interface IBookAppService
    {
        Task<IEnumerable<BookDto>> GetBooks();
        Task<BookDto> GetBook(int id);
        Task<IEnumerable<BookDto>> GetBook(string searchValue);
        Task Create(BookDto bookDto);
    }
}
