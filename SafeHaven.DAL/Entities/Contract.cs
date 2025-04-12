namespace SafeHaven.DAL.Entities;

/// <summary>
/// Представляет договор страхования, заключенный между клиентом и страховой компанией.
/// </summary>
public class Contract : BaseEntity
{
    /// <summary>
    /// Дата начала действия договора.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата окончания действия договора.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Страховая сумма, указанная в договоре.
    /// </summary>
    public decimal InsuranceAmount { get; set; }

    /// <summary>
    /// Страховая премия, уплачиваемая клиентом.
    /// </summary>
    public decimal PremiumAmount { get; set; }

    /// <summary>
    /// Статус договора (активен/неактивен).
    /// </summary>
    public bool ContractStatus { get; set; }

    /// <summary>
    /// Клиент, заключивший данный договор.
    /// </summary>
    public Client Client { get; set; }

    /// <summary>
    /// Тип страхования, применяемый в данном договоре.
    /// </summary>
    public InsuranceType InsuranceType { get; set; }

    /// <summary>
    /// Коллекция страховых случаев, связанных с данным договором.
    /// Доступна только для чтения.
    /// </summary>
    public List<InsuranceCase> InsuranceCases { get; set; } = [];

    /// <summary>
    /// Коллекция платежей по данному договору.
    /// Доступна только для чтения.
    /// </summary>
    public List<Payment> Payments { get; set; } = [];

    public Contract(DateTime startDate, DateTime endDate, decimal insuranceAmount, decimal premiumAmount,
        bool contractStatus, Client client, InsuranceType insuranceType)
    {
        StartDate = startDate;
        EndDate = endDate;
        InsuranceAmount = insuranceAmount;
        PremiumAmount = premiumAmount;
        ContractStatus = contractStatus;
        Client = client;
        InsuranceType = insuranceType;
    }

    // ReSharper disable once UnusedMember.Local
    private Contract()
    {
    }
}