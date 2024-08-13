using EliteInsurance.Data.Configuration;
using EliteInsurance.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteInsurance.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureClaim();
        modelBuilder.ConfigureClaimType();
        modelBuilder.ConfigureCompany();
    }

    public DbSet<Claim> Claims { get; set; }
    public DbSet<ClaimType> ClaimTypes { get; set; }
    public DbSet<Company> Companies { get; set; }
}

