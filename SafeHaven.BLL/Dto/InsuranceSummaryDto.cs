﻿namespace SafeHaven.BLL.Dto;

public class InsuranceSummaryDto
{
    public required string InsuranceTypeName { get; set; }
    public int ContractsCount { get; set; }
    public decimal TotalInsuranceAmount { get; set; }
    public decimal TotalPremiumAmount { get; set; }
}