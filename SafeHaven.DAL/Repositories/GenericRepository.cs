using Microsoft.EntityFrameworkCore;
using SafeHaven.DAL.Entities;
using SafeHaven.DAL.Interfaces;

namespace SafeHaven.DAL.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
{
    protected readonly InsuranceDbContext Context;

    protected GenericRepository(InsuranceDbContext context)
    {
        Context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(object? id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await Context.AddAsync(entity);
    }

    public void Update(T entity)
    {
        Context.Update(entity);
    }

    public void Remove(T entity)
    {
        Context.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}