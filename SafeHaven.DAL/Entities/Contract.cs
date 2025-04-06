namespace SafeHaven.DAL.Entities;

public class Contract : BaseEntity
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal InsuranceAmount { get; private set; }
    public decimal PremiumAmount { get; private set; }
    public bool ContractStatus { get; private set; }

    public Client Client { get; set; }
    public InsuranceType InsuranceType { get; set; }

    public IReadOnlyCollection<InsuranceCase> InsuranceCases => insuranceCases.AsReadOnly();
    private readonly List<InsuranceCase> insuranceCases = [];
    public IReadOnlyCollection<Payment> Payments { get; set; }
    private readonly List<Payment> payments = [];


    public Contract(DateTime startDate, DateTime endDate, decimal insuranceAmount, decimal premiumAmount,
        bool contractStatus)
    {
        StartDate = startDate;
        EndDate = endDate;
        InsuranceAmount = insuranceAmount;
        PremiumAmount = premiumAmount;
        ContractStatus = contractStatus;
    }
}