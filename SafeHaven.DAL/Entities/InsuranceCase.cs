namespace SafeHaven.DAL.Entities;

/// <summary>
/// Представляет страховой случай, связанный с договором страхования.
/// </summary>
public class InsuranceCase : BaseEntity
{
    /// <summary>
    /// Дата, когда произошел страховой случай.
    /// </summary>
    public DateTime CaseDate { get; set; }
        
    /// <summary>
    /// Описание страхового случая.
    /// </summary>
    public string Description { get; set; }
        
    /// <summary>
    /// Сумма выплаты по страховому случаю.
    /// </summary>
    public decimal PayoutAmount { get; set; }
        
    /// <summary>
    /// Договор, к которому относится данный страховой случай.
    /// </summary>
    public Contract Contract { get; set; }

    /// <summary>
    /// Создает новый экземпляр страхового случая.
    /// </summary>
    /// <param name="caseDate">Дата страхового случая.</param>
    /// <param name="description">Описание случившегося.</param>
    /// <param name="payoutAmount">Сумма выплаты по страховому случаю.</param>
    public InsuranceCase(DateTime caseDate, string description, decimal payoutAmount)
    {
        CaseDate = caseDate;
        Description = description;
        PayoutAmount = payoutAmount;
    }
}