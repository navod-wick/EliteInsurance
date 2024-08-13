using EliteInsurance.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteInsurance.Data.Configuration;

public static class CompanyConfiguration
{
    public static void ConfigureCompany(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(co => co.Id);

            entity.Property(co => co.Name)
                .HasMaxLength(200);

            entity.Property(co => co.Address1)
                .HasMaxLength(100);

            entity.Property(co => co.Address2)
                .HasMaxLength(100);

            entity.Property(co => co.Address3)
                .HasMaxLength(100);

            entity.Property(co => co.Postcode)
                .HasMaxLength(20);

            entity.Property(co => co.Country)
                .HasMaxLength(50);
        });
    }
}

