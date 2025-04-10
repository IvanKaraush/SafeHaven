using SafeHaven.DAL.Entities;

namespace SafeHaven.DAL.Interfaces;

public interface IContractRepository : IGenericRepository<Contract>
{
    Task<Contract?> GetContractByIdAsync(int id);

    /// <summary>
    /// Получает договоры, у которых значение премии меньше заданного.
    /// </summary>
    Task<IEnumerable<Contract>> GetContractsWithPremiumLessThanAsync(decimal premium);

    /// <summary>
    /// Получает договоры, у которых значение премии больше заданного.
    /// </summary>
    Task<IEnumerable<Contract>> GetContractsWithPremiumGreaterThanAsync(decimal premium);

    /// <summary>
    /// Получает договоры для указанного типа страхования.
    /// </summary>
    Task<IEnumerable<Contract>> GetContractsByInsuranceTypeAsync(string insuranceTypeName);

    /// <summary>
    /// Получает действующие договоры.
    /// Договор считается действующим, если его статус активен и текущая дата находится между StartDate и EndDate.
    /// </summary>
    Task<IEnumerable<Contract>> GetActiveContractsAsync(DateTime currentDate);
}