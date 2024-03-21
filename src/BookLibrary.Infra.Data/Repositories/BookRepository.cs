using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Interfaces.Repositories;
using BookLibrary.Infra.Data.Context;

namespace BookLibrary.Infra.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
