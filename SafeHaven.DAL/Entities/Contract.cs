namespace SafeHaven.DAL.Entities;

/// <summary>
/// Представляет договор страхования, заключенный между клиентом и страховой компанией.
/// </summary>
public class Contract : BaseEntity
{
    /// <summary>
    /// Дата начала действия договора.
    /// </summary>
    public DateTime StartDate { get; private set; }

    /// <summary>
    /// Дата окончания действия договора.
    /// </summary>
    public DateTime EndDate { get; private set; }

    /// <summary>
    /// Страховая сумма, указанная в договоре.
    /// </summary>
    public decimal InsuranceAmount { get; private set; }

    /// <summary>
    /// Страховая премия, уплачиваемая клиентом.
    /// </summary>
    public decimal PremiumAmount { get; private set; }

    /// <summary>
    /// Статус договора (активен/неактивен).
    /// </summary>
    public bool ContractStatus { get; private set; }

    /// <summary>
    /// Клиент, заключивший данный договор.
    /// </summary>
    public Client Client { get; private set; }

    /// <summary>
    /// Тип страхования, применяемый в данном договоре.
    /// </summary>
    public InsuranceType InsuranceType { get; private set; }

    public List<InsuranceCase> InsuranceCases { get; private set; } = [];

    public List<Payment> Payments { get; private set; } = [];

    public Contract(
        DateTime startDate,
        DateTime endDate,
        decimal insuranceAmount,
        decimal premiumAmount,
        bool contractStatus,
        Client client,
        InsuranceType insuranceType,
        List<Payment> payments,
        List<InsuranceCase> insuranceCases )
    {
        if (endDate < startDate)
            throw new ArgumentException("Дата окончания не может быть раньше даты начала.", nameof(endDate));

        StartDate = startDate;
        EndDate = endDate;
        InsuranceAmount = insuranceAmount;
        PremiumAmount = premiumAmount;
        ContractStatus = contractStatus;
        Client = client ?? throw new ArgumentNullException(nameof(client));
        InsuranceType = insuranceType ?? throw new ArgumentNullException(nameof(insuranceType));
        Payments = payments;
        InsuranceCases = insuranceCases;
    }

    // ReSharper disable once UnusedMember.Local
    private Contract()
    {
    }

    public void Update(
        DateTime newStartDate,
        DateTime newEndDate,
        decimal newInsuranceAmount,
        decimal newPremiumAmount,
        bool newContractStatus,
        string newClientFullName,
        DateTime newClientDateOfBirth,
        string newClientPassportNumber,
        string newClientAddress,
        string newClientPhone,
        string newClientEmail,
        string newInsuranceTypeName,
        string newInsuranceTypeDescription)
    {
        if (newEndDate < newStartDate)
            throw new ArgumentException("Дата окончания не может быть раньше даты начала.");

        StartDate = newStartDate;
        EndDate = newEndDate;
        InsuranceAmount = newInsuranceAmount;
        PremiumAmount = newPremiumAmount;
        ContractStatus = newContractStatus;

        Client.Update(
            newClientFullName,
            newClientDateOfBirth,
            newClientPassportNumber,
            newClientAddress,
            newClientPhone,
            newClientEmail);

        InsuranceType.Update(
            newInsuranceTypeName,
            newInsuranceTypeDescription);
    }

    public void AddPayment(Payment payment)
    {
        
    }
}