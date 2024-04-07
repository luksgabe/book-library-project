using BookLibrary.Application.Books.Events;
using BookLibrary.Application.Mediator;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Interfaces.Repositories;
using BookLibrary.Domain.Interfaces.SeedWork;
using FluentValidation.Results;
using MediatR;

namespace BookLibrary.Application.Books.Commands
{
    public class BookCommandHandler : CommandHandlerBase,
        IRequestHandler<RegisterBookCommand, ValidationResult>
    {

        private readonly IBookRepository _bookRepository;

        public BookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository) : base(unitOfWork)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ValidationResult> Handle(RegisterBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(
                request.Title,
                request.FirstName,
                request.LastName,
                request.TotalCopies,
                request.CopiesInUse,
                request.Type,
                request.Isbn,
                request.Category);

            book.AddDomainEvent(new BookRegisterEvent(request.Title,
                request.FirstName,
                request.LastName,
                request.TotalCopies,
                request.CopiesInUse,
                request.Type,
                request.Isbn,
                request.Category));

            await _bookRepository.AddAsync(book);
            return await Commit();
        }
    }
}
