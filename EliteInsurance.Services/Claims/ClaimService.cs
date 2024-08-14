using EliteInsurance.Data;
using EliteInsurance.Data.Dtos;
using EliteInsurance.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EliteInsurance.Services.Claims;

public class ClaimService : IClaimService
{
    private readonly DatabaseContext _context;
    private readonly ILogger<ClaimService> _logger;

    public ClaimService(
        DatabaseContext context,
        ILogger<ClaimService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<ClaimDto>?> GetByCompanyIdAsync(int companyId, CancellationToken token)
    {
        try
        {
            return await _context.Claims.Where(c => c.CompanyId == companyId)
                .Select(claim => CreateClaimDto(claim))
                .ToListAsync(token);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception in {nameof(GetByCompanyIdAsync)}", ex);
            return null;
        }
    }

    public async Task<ClaimDto?> GetDetailsAsync(string ucr, CancellationToken token)
    {
        try
        {
            return await _context.Claims.Where(c => c.UCR == ucr)
                .Select(claim => CreateClaimDto(claim))
                .SingleOrDefaultAsync(token) ?? new ClaimDto();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception in {nameof(GetByCompanyIdAsync)}", ex);
            return null;
        }
    }
    
    public async Task<(bool success, bool exception)> UpdateClaimAsync(ClaimUpdateRequestDto claim, CancellationToken token)
    {
        try
        {
            var claimEntity = await _context.Claims.SingleOrDefaultAsync(c => c.UCR == claim.UCR, token);

            if (claimEntity != null)
            {
                claimEntity.CompanyId = claim.CompanyId;
                claimEntity.ClaimDate = claim.ClaimDate;
                claimEntity.LossDate = claim.LossDate;
                claimEntity.AssuredName = claim.AssuredName;
                claimEntity.IncurredLoss = claim.IncurredLoss;
                claimEntity.Closed = claim.Closed;
                claimEntity.ClaimTypeId = claim.ClaimTypeId;
                _context.Update(claimEntity);
                await _context.SaveChangesAsync(token);
                return (true, false);
            }
            _logger.LogWarning($"Requested Claim was not found, reference:{claim.UCR}");
            return (false, false);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception in {nameof(GetByCompanyIdAsync)}", ex);
            return (false, true);
        }
    }

    private static ClaimDto CreateClaimDto(Claim claim)
    {
        return new ClaimDto
        {
            CompanyId = claim.CompanyId,
            AssuredName = claim.AssuredName,
            ClaimDate = claim.ClaimDate,
            Closed = claim.Closed,
            IncurredLoss = claim.IncurredLoss,
            LossDate = claim.LossDate,
            ClaimTypeId = claim.ClaimTypeId,
            UCR = claim.UCR,
            AgeOfClaim = (DateTime.UtcNow - claim.ClaimDate).Days,
        };
    }
}

