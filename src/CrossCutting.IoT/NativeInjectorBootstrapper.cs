using BookLibrary.Application.Books.Commands;
using BookLibrary.Application.Books.Events;
using BookLibrary.Application.Books.Queries;
using BookLibrary.Application.DataTransferObjects;
using BookLibrary.Application.Interfaces.Mediator;
using BookLibrary.CrossCutting.Bus;
using BookLibrary.Data;
using BookLibrary.Data.Context;
using BookLibrary.Data.EventSourcing;
using BookLibrary.Data.Repositories;
using BookLibrary.Domain.Interfaces.Repositories;
using BookLibrary.Domain.Interfaces.SeedWork;
using BookLibrary.Infra.Data.Context;
using BookLibrary.Infra.Data.Repositories;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoT
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, Bus>();

            //Command Handlers
            services.AddScoped<IRequestHandler<RegisterBookCommand, ValidationResult>, BookCommandHandler>();

            //Query Handlers
            services.AddScoped<IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>, BookQueryHandler>();
            services.AddScoped<IRequestHandler<GetBookByIdQuery, BookDto>, BookQueryHandler>();
            services.AddScoped<IRequestHandler<GetBookByTermQuery, IEnumerable<BookDto>>, BookQueryHandler>();

            //Event Handlers
            services.AddTransient<BookEventHandler>();
            services.AddScoped<INotificationHandler<BookRegisterEvent>, BookEventHandler>();

            //Infra - UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Repositories
            services.AddScoped<IBookRepository, BookRepository>();

            //Infra - Contexts
            services.AddScoped<AppDbContext>();

            //Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}