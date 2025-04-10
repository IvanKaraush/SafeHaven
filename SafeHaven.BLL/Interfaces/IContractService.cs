using SafeHaven.BLL.Dto;

namespace SafeHaven.BLL.Interfaces;

public interface IContractService
{
    Task<ContractDto?> GetContractByIdAsync(Guid id);
    Task<IEnumerable<ContractDto>> GetAllContractsAsync();
    Task<IEnumerable<ContractDto>> GetContractsWithPremiumLessThanAsync(decimal premium);
    Task<IEnumerable<ContractDto>> GetContractsWithPremiumGreaterThanAsync(decimal premium);
    Task<InsuranceSummaryDto> GetSummaryByInsuranceTypeAsync(string insuranceTypeName);
    Task<IEnumerable<ContractDto>> GetActiveContractsAsync();
    Task<ContractDto> CreateContractAsync(ContractDto contractDto);
    Task UpdateAsync(ContractDto contractDto);
    Task DeleteAsync(Guid id);
}