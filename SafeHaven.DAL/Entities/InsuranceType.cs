namespace SafeHaven.DAL.Entities;

/// <summary>
/// Представляет тип страхования, определяющий характеристики и описание вида страховки.
/// </summary>
public class InsuranceType : BaseEntity
{
    /// <summary>
    /// Название типа страхования.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание типа страхования.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Коллекция договоров, применяющих этот тип страхования.
    /// Доступна только для чтения.
    /// </summary>
    public List<Contract> Contracts { get; set; } = [];

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
}