﻿namespace SafeHaven.BLL.Dto;

public class ContractDto
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal InsuranceAmount { get; set; }
    public decimal PremiumAmount { get; set; }
    public bool ContractStatus { get; set; }
    public required ClientDto Client { get; set; }
    public required InsuranceTypeDto InsuranceType { get; set; }
    public List<InsuranceCaseDto> InsuranceCases { get; set; } = [];
    public List<PaymentDto> Payments { get; set; } = [];
}