namespace SafeHaven.BLL.Dto;

public class InsuranceTypeDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}