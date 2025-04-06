namespace SafeHaven.DAL.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<T[]> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    void Add(T entity);
    void Delete(T entity);
}