using EliteInsurance.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteInsurance.Data.Configuration;

public static class ClaimConfiguration
{
    public static void ConfigureClaim(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(c => c.UCR);

            entity.Property(c => c.UCR)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(c => c.AssuredName)
                .HasColumnName("Assured Name")
                .HasMaxLength(100);

            entity.Property(c => c.IncurredLoss)
                .HasColumnName("Incurred Loss")
                .HasColumnType("decimal(15,2)");

            entity.HasOne(c => c.ClaimType)
                .WithMany(ct => ct.Claims)
                .HasForeignKey(c => c.ClaimTypeId);

            entity.HasOne(c => c.Company)
                .WithMany(co => co.Claims)
                .HasForeignKey(c => c.CompanyId);
        });
    }
}

