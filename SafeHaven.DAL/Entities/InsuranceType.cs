namespace SafeHaven.DAL.Entities;

/// <summary>
/// Представляет тип страхования, определяющий характеристики и описание вида страховки.
/// </summary>
public class InsuranceType : BaseEntity
{
    private string _name;
    private string _description;

    /// <summary>
    /// Название типа страхования.
    /// </summary>
    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Название типа страхования не может быть пустым.", nameof(Name));
            _name = value;
        }
    }

    /// <summary>
    /// Описание типа страхования.
    /// </summary>
    public string Description
    {
        get => _description;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Описание типа страхования не может быть пустым.", nameof(Description));
            _description = value;
        }
    }

    /// <summary>
    /// Коллекция договоров, применяющих этот тип страхования.
    /// Доступна только для чтения.
    /// </summary>
    public List<Contract> Contracts { get; private set; } = new();

    /// <summary>
    /// Создает новый экземпляр типа страхования.
    /// </summary>
    /// <param name="name">Название типа страхования.</param>
    /// <param name="description">Описание типа страхования.</param>
    public InsuranceType(string name, string description)
    {
        Name = name;
        Description = description;
    }

    // Для работы EF Core требуется параметрless конструктор.
    private InsuranceType() { }

    /// <summary>
    /// Обновляет свойства типа страхования.
    /// </summary>
    /// <param name="newName">Новое название типа.</param>
    /// <param name="newDescription">Новое описание.</param>
    internal void Update(string newName, string newDescription)
    {
        Name = newName;
        Description = newDescription;
    }
}