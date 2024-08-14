using EliteInsurance.Data.Dtos;
using EliteInsurance.Data.Entities;

namespace EliteInsurance.Services.Companies;

public interface ICompanyService
{
    Task<CompanyDto?> GetByIdAsync(int id, CancellationToken token);
}

