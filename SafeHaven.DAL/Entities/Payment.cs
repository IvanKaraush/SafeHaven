namespace SafeHaven.DAL.Entities;

public class Payment : BaseEntity
{
    public DateTime PaymentDate { get; private set; }
    public decimal Amount { get; private set; }

    public Contract Contract { get; private set; }

    public Payment(DateTime paymentDate, decimal amount)
    {
        PaymentDate = paymentDate;
        Amount = amount;
    }
}