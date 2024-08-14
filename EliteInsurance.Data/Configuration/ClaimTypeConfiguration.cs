using EliteInsurance.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteInsurance.Data.Configuration;

public static class ClaimTypeConfiguration
{
    public static void ConfigureClaimType(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClaimType>(entity =>
        {
            entity.ToTable("ClaimType");
            entity.HasKey(ct => ct.Id);

            entity.Property(ct => ct.Name)
                .HasMaxLength(20);
        });
    }
}

