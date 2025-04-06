namespace SafeHaven.DAL.Entities;

public class InsuranceType : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public IReadOnlyCollection<Contract> Contracts => contracts.AsReadOnly();
    public List<Contract> contracts = [];

    public InsuranceType(string name, string description)
    {
        Name = name;
        Description = description;
    }
}