namespace SafeHaven.BLL.Interfaces;

public interface IBaseCrudService<TApiContract, TId>
{
    Task<TApiContract> GetByIdAsync(TId id);
    Task<TApiContract[]> GetItemWithPaginationAsync(int page, int pageSize);
    Task<TId> CreateAsync(TApiContract apiContract);
    Task UpdateAsync(TApiContract apiContract);
    Task DeleteAsync(TId id);
}