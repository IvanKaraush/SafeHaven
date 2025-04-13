namespace SafeHaven.DAL.Entities;

/// <summary>
/// Представляет платеж, произведенный по договору страхования.
/// </summary>
public class Payment : BaseEntity
{
    /// <summary>
    /// Дата платежа.
    /// </summary>
    public DateTime PaymentDate { get; set; }
        
    /// <summary>
    /// Сумма платежа.
    /// </summary>
    public decimal Amount { get; set; }
        
    /// <summary>
    /// Договор, к которому относится данный платеж.
    /// </summary>
    public Contract Contract { get; set; }

    /// <summary>
    /// Создает новый экземпляр платежа.
    /// </summary>
    /// <param name="paymentDate">Дата платежа.</param>
    /// <param name="amount">Сумма платежа.</param>
    public Payment(DateTime paymentDate, decimal amount)
    {
        PaymentDate = paymentDate;
        Amount = amount;
    }
}