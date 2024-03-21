using System.Linq.Expressions;


namespace BookLibrary.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetCustomData(Expression<Func<TEntity, bool>> expression);
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(TEntity entity);
    }
}
