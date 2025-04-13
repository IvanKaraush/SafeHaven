using SafeHaven.BLL.Dto;

namespace SafeHaven.BLL.Interfaces;

public interface IContractService : IBaseCrudService<ContractDto, Guid>
{
    Task<IEnumerable<PaymentDto>> GetPaymentByContractIdAsync(Guid id);
    Task<IEnumerable<InsuranceTypeDto>> GetInsuranceTypeWithPaginationAsync(int page, int pageSize);
    Task<InsuranceCaseDto[]> GetInsuranceCaseByContractIdAsync(Guid id);
    Task<InsuranceTypeDto> GetInsuranceTypeByIdAsync(Guid id);
    Task<IEnumerable<ContractDto>> GetContractsWithPremiumLessThanAsync(decimal premium);
    Task<IEnumerable<ContractDto>> GetContractsWithPremiumGreaterThanAsync(decimal premium);
    Task<InsuranceSummaryDto> GetSummaryByInsuranceTypeAsync(string insuranceTypeName);
    Task<IEnumerable<ContractDto>> GetActiveContractsAsync();
}