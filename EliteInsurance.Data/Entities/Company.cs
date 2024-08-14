namespace EliteInsurance.Data.Entities;

public class Company
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    public required string Postcode { get; set; }
    public required string Country { get; set; }
    public bool Active { get; set; }
    public DateTime InsuranceEndDate { get; set; }
    public virtual ICollection<Claim>? Claims { get; set; }
}

