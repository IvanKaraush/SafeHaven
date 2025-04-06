namespace SafeHaven.DAL.Entities;

public class Client : BaseEntity
{
    public string FullName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string PassportNumber { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public IReadOnlyCollection<Contract> Contracts => _contracts.AsReadOnly();
    private readonly List<Contract> _contracts = [];

    public Client(string fullName, DateTime dateOfBirth, string passportNumber, string address, string phone, string email)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        PassportNumber = passportNumber;
        Address = address;
        Phone = phone;
        Email = email;
    }
}