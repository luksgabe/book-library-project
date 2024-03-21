using BookLibrary.Domain.Interfaces.Repositories;
using BookLibrary.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookLibrary.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet => _context.Set<TEntity>();
        protected DbContext _context { get; }

        public Repository(AppDbContext context)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }
        public virtual async Task AddAsync(TEntity obj)
        {
            await _dbSet.AddAsync(obj);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetCustomData(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            await Task.FromResult(_dbSet.Remove(entity));
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            await Task.Run(() => _dbSet.Update(obj));
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
