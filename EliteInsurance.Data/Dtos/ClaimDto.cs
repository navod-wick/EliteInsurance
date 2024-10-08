﻿namespace EliteInsurance.Data.Dtos;

public class ClaimDto
{
    public string UCR { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public int ClaimTypeId { get; set; }
    public DateTime ClaimDate { get; set; }
    public DateTime LossDate { get; set; }
    public string AssuredName { get; set; } = string.Empty;
    public decimal IncurredLoss { get; set; }
    public bool Closed { get; set; }
    public int AgeOfClaim { get; set; }
}

