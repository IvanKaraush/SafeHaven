using SafeHaven.BLL.Dto;

namespace SafeHaven.BLL.Interfaces;

public interface IContractService : IBaseCrudService<ContractDto, Guid>
{
    Task<IEnumerable<ContractDto>> GetContractsWithPremiumLessThanAsync(decimal premium);
    Task<IEnumerable<ContractDto>> GetContractsWithPremiumGreaterThanAsync(decimal premium);
    Task<InsuranceSummaryDto> GetSummaryByInsuranceTypeAsync(string insuranceTypeName);
    Task<IEnumerable<ContractDto>> GetActiveContractsAsync();
}