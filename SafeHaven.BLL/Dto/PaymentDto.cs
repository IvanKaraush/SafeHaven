namespace SafeHaven.BLL.Dto;

public class PaymentDto
{
    public Guid Id { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
}