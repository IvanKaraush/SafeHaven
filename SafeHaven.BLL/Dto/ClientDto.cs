namespace SafeHaven.BLL.Dto;

public class ClientDto
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string PassportNumber { get; set; }
    public required string Address { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
}