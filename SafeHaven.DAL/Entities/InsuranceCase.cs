namespace SafeHaven.DAL.Entities;

public class InsuranceCase : BaseEntity
{
    public DateTime CaseDate { get; private set; }
    public string Description { get; private set; }
    public decimal PayoutAmount { get; private set; }
    public Contract Contract { get; private set; }

    public InsuranceCase(DateTime caseDate, string description, decimal payoutAmount)
    {
        CaseDate = caseDate;
        Description = description;
        PayoutAmount = payoutAmount;
    }
}