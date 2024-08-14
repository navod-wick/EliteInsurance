using EliteInsurance.Data;
using EliteInsurance.Data.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EliteInsurance.Services.Companies;

public class CompanyService : ICompanyService
{
    private readonly ILogger<CompanyService> _logger;
    private readonly DatabaseContext _context;

    public CompanyService(
        ILogger<CompanyService> logger,
        DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<CompanyDto?> GetByIdAsync(int id, CancellationToken token)
    {
        try
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id, token);

            if (company == null)
            {
                _logger.LogWarning($"Requested Company was not found, companyId:{id}");
                return new CompanyDto(){CompanyId = -1};
            }
            else
            {
                return new CompanyDto()
                {
                    CompanyId = company.Id,
                    CompanyName = company.Name,
                    Active = company.Active,
                    Address1 = company.Address1,
                    Address2 = company.Address2 ?? string.Empty,
                    Address3 = company.Address3 ?? string.Empty,
                    Country = company.Country,
                    PostCode = company.Postcode,
                    InsuranceEndDate = company.InsuranceEndDate,
                    HasActiveInsurance = (company.Active && company.InsuranceEndDate > DateTime.UtcNow),
                };

            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception in {nameof(GetByIdAsync)}", ex);
            return null;
        }
    }
}

