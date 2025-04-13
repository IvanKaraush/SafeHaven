using System.Linq.Expressions;
using SafeHaven.DAL.Entities;

namespace SafeHaven.DAL.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetPaginatedAsync(int page, int pageSize);
    Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task SaveChangesAsync();
}