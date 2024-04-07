using BookLibrary.Application.Interfaces.Mediator;
using BookLibrary.Application.Mediator;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Interfaces.SeedWork;
using BookLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace BookLibrary.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appContext;
        private readonly IMediatorHandler _mediatorHandler;

        public UnitOfWork(AppDbContext appContext, IMediatorHandler mediatorHandler)
        {
            this._appContext = appContext;
            this._mediatorHandler = mediatorHandler;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediatorHandler.PublishDomainEvents(_appContext).ConfigureAwait(false);

            return await this._appContext.SaveChangesAsync(cancellationToken);
        }

    }

    public static class MediatorExtension
    {
        public static async Task PublishDomainEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.PublishEvent((Event)domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
