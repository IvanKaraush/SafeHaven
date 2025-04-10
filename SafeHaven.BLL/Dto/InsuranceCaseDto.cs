namespace SafeHaven.BLL.Dto;

public class InsuranceCaseDto
{
    public Guid Id { get; set; }
    public DateTime CaseDate { get; set; }
    public string Description { get; set; }
    public decimal PayoutAmount { get; set; }
    public int ContractId { get; set; }
}