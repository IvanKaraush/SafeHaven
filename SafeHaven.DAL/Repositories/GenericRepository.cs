using Microsoft.EntityFrameworkCore;
using SafeHaven.DAL.Entities;

namespace SafeHaven.DAL.Repositories;

public abstract class GenericRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly InsuranceDbContext Context;

    protected GenericRepository(InsuranceDbContext context)
    {
        Context = context;
    }

    public async Task<T[]> GetAllAsync()
    {
        return await Context.Set<T>().ToArrayAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(c => c.Id == id);
    }

    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
    }
}