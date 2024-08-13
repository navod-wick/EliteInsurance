namespace EliteInsurance.Data.Entities;

public class ClaimType
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual ICollection<Claim>? Claims { get; set; }

}

