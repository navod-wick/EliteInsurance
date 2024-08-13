namespace EliteInsurance.Data.Entities;

public class Claim
{
    public required string UCR { get; set; }
    public int ClaimTypeId { get; set; }
    public int CompanyId { get; set; }
    public DateTime ClaimDate { get; set; }
    public DateTime LossDate { get; set; }
    public required string AssuredName { get; set; }
    public decimal IncurredLoss { get; set; }
    public bool Closed { get; set; }
    public virtual required ClaimType ClaimType { get; set; }
    public virtual required Company Company { get; set; }
}

