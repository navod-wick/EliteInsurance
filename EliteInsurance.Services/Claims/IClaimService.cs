using EliteInsurance.Data.Dtos;

namespace EliteInsurance.Services.Claims;

public interface IClaimService
{
    Task<IEnumerable<ClaimDto>?> GetByCompanyIdAsync(int  companyId, CancellationToken token);
    Task<ClaimDto?> GetDetailsAsync(string ucr, CancellationToken token);
    Task<(bool success, bool exception)> UpdateClaimAsync(ClaimUpdateRequestDto claim, CancellationToken token);
}

