namespace SafeHaven.DAL.Entities;

/// <summary>
/// Представляет клиента страховой компании.
/// Содержит персональные данные и коллекцию договоров, заключенных данным клиентом.
/// </summary>
public class Client : BaseEntity
{
    private string _fullName;
    private string _passportNumber;
    private string _address;
    private string _phone;
    private string _email;

    /// <summary>
    /// Полное имя клиента.
    /// </summary>
    public string FullName
    {
        get => _fullName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Имя клиента не может быть пустым.", nameof(FullName));
            _fullName = value;
        }
    }

    /// <summary>
    /// Дата рождения клиента.
    /// </summary>
    public DateTime DateOfBirth { get; private set; }

    /// <summary>
    /// Номер паспорта клиента.
    /// </summary>
    public string PassportNumber
    {
        get => _passportNumber;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Номер паспорта не может быть пустым.", nameof(PassportNumber));
            _passportNumber = value;
        }
    }

    /// <summary>
    /// Адрес проживания клиента.
    /// </summary>
    public string Address
    {
        get => _address;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Адрес не может быть пустым.", nameof(Address));
            _address = value;
        }
    }

    /// <summary>
    /// Контактный телефон клиента.
    /// </summary>
    public string Phone
    {
        get => _phone;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Телефон не может быть пустым.", nameof(Phone));
            _phone = value;
        }
    }

    /// <summary>
    /// Электронная почта клиента.
    /// </summary>
    public string Email
    {
        get => _email;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Электронная почта не может быть пустой.", nameof(Email));
            _email = value;
        }
    }

    /// <summary>
    /// Коллекция договоров страхования, заключенных с данным клиентом.
    /// Доступна только для чтения.
    /// </summary>
    public List<Contract> Contracts { get; private set; } = new();

    /// <summary>
    /// Создает новый экземпляр клиента.
    /// </summary>
    /// <param name="fullName">Полное имя клиента.</param>
    /// <param name="dateOfBirth">Дата рождения клиента.</param>
    /// <param name="passportNumber">Номер паспорта клиента.</param>
    /// <param name="address">Адрес клиента.</param>
    /// <param name="phone">Телефон клиента.</param>
    /// <param name="email">Электронная почта клиента.</param>
    public Client(string fullName, DateTime dateOfBirth, string passportNumber, string address, string phone, string email)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        PassportNumber = passportNumber;
        Address = address;
        Phone = phone;
        Email = email;
    }

    // Для EF Core требуется параметрless конструктор.
    private Client() { }

    /// <summary>
    /// Обновляет свойства клиента.
    /// </summary>
    /// <param name="newFullName">Новое полное имя.</param>
    /// <param name="newDateOfBirth">Новая дата рождения.</param>
    /// <param name="newPassportNumber">Новый номер паспорта.</param>
    /// <param name="newAddress">Новый адрес.</param>
    /// <param name="newPhone">Новый телефон.</param>
    /// <param name="newEmail">Новая электронная почта.</param>
    public void Update(
        string newFullName,
        DateTime newDateOfBirth,
        string newPassportNumber,
        string newAddress,
        string newPhone,
        string newEmail)
    {
        FullName = newFullName;
        DateOfBirth = newDateOfBirth;
        PassportNumber = newPassportNumber;
        Address = newAddress;
        Phone = newPhone;
        Email = newEmail;
    }
}