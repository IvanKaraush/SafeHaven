using AutoMapper;
using SafeHaven.BLL.Dto;
using SafeHaven.BLL.Exceptions;
using SafeHaven.BLL.Interfaces;
using SafeHaven.DAL.Entities;
using SafeHaven.DAL.Interfaces;

namespace SafeHaven.BLL.Services;

public class ContractService : IContractService
{
    private readonly IMapper _mapper;
    private readonly IContractRepository _contractRepository;

    public ContractService(IMapper mapper, IContractRepository contractRepository)
    {
        _mapper = mapper;
        _contractRepository = contractRepository;
    }

    public async Task<IEnumerable<ContractDto>> GetContractsWithPremiumLessThanAsync(decimal premium)
    {
        var contracts = await _contractRepository.GetContractsWithPremiumLessThanAsync(premium);
        return _mapper.Map<IEnumerable<ContractDto>>(contracts);
    }

    public async Task<IEnumerable<ContractDto>> GetContractsWithPremiumGreaterThanAsync(decimal premium)
    {
        var contracts = await _contractRepository.GetContractsWithPremiumGreaterThanAsync(premium);
        return _mapper.Map<IEnumerable<ContractDto>>(contracts);
    }

    public async Task<InsuranceSummaryDto> GetSummaryByInsuranceTypeAsync(string insuranceTypeName)
    {
        var contracts = await _contractRepository.GetContractsByInsuranceTypeAsync(insuranceTypeName);

        return _mapper.Map<InsuranceSummaryDto>(contracts);
    }

    public async Task<IEnumerable<ContractDto>> GetActiveContractsAsync()
    {
        var contracts = await _contractRepository.GetActiveContractsAsync(DateTime.UtcNow);
        return _mapper.Map<IEnumerable<ContractDto>>(contracts);
    }

    public async Task<ContractDto> GetByIdAsync(Guid id)
    {
        var client = await _contractRepository.GetByFilterAsync(c => c.Id == id) ??
                     throw new NotFoundException($"Не найден клиент {id}");
        return _mapper.Map<ContractDto>(client);
    }

    public async Task<ContractDto[]> GetItemWithPaginationAsync(int page, int pageSize)
    {
        var contracts = await _contractRepository.GetPaginatedAsync(page, pageSize);
        return _mapper.Map<ContractDto[]>(contracts);
    }

    public async Task<Guid> CreateAsync(ContractDto contractDto)
    {
        var contract = new Contract(contractDto.StartDate, contractDto.EndDate, contractDto.InsuranceAmount,
            contractDto.PremiumAmount, contractDto.ContractStatus,
            new Client(contractDto.Client.FullName, contractDto.Client.DateOfBirth, contractDto.Client.PassportNumber,
                contractDto.Client.Address, contractDto.Client.Phone, contractDto.Client.Email),
            new InsuranceType(contractDto.InsuranceType.Name, contractDto.InsuranceType.Description));
        await _contractRepository.AddAsync(contract);
        await _contractRepository.SaveChangesAsync();
        return contract.Id;
    }

    public async Task UpdateAsync(ContractDto contractDto)
    {
        var contract = await _contractRepository.GetContractByIdAsync(contractDto.Id) ??
                       throw new NotFoundException($"Не найден контракт {contractDto.Id}");

        contract.Update(contractDto.StartDate, contractDto.EndDate, contractDto.InsuranceAmount,
            contractDto.PremiumAmount, contractDto.ContractStatus, contractDto.Client.FullName,
            contractDto.Client.DateOfBirth, contractDto.Client.PassportNumber, contractDto.Client.Address,
            contractDto.Client.Phone, contractDto.Client.Email, contractDto.InsuranceType.Name,
            contractDto.InsuranceType.Description);
        await _contractRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var contract = await _contractRepository.GetByFilterAsync(c => c.Id == id) ??
                       throw new NotFoundException($"Не найден контракт {id}");
        _contractRepository.Remove(contract);
        await _contractRepository.SaveChangesAsync();
    }
}