using Microsoft.EntityFrameworkCore;
using SafeHaven.DAL.Entities;
using SafeHaven.DAL.Interfaces;

namespace SafeHaven.DAL.Repositories;

public class ContractRepository(InsuranceDbContext context) : GenericRepository<Contract>(context), IContractRepository
{
    public async Task<Contract?> GetContractByIdAsync(int id)
    {
        return await Context.Contracts.FindAsync(id);
    }

    public async Task<IEnumerable<Contract>> GetContractsWithPremiumLessThanAsync(decimal premium)
    {
        return await Context.Contracts.Where(c => c.PremiumAmount < premium).ToListAsync();
    }

    public async Task<IEnumerable<Contract>> GetContractsWithPremiumGreaterThanAsync(decimal premium)
    {
        return await Context.Contracts.Where(c => c.PremiumAmount > premium).ToListAsync();
    }

    public async Task<IEnumerable<Contract>> GetContractsByInsuranceTypeAsync(string insuranceTypeName)
    {
        return await Context.Contracts
            .Include(c => c.InsuranceType)
            .Where(c => c.InsuranceType.Name == insuranceTypeName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Contract>> GetActiveContractsAsync(DateTime currentDate)
    {
        return await Context.Contracts
            .Where(c => c.ContractStatus && c.StartDate <= currentDate && currentDate <= c.EndDate)
            .ToListAsync();
    }
}