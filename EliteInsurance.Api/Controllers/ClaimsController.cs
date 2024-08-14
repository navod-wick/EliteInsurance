using EliteInsurance.Data.Dtos;
using EliteInsurance.Services.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EliteInsurance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimService _claimService;
        private const string ErrorMessage = "There was an error when handling your request please contact system admin";
        public ClaimsController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpGet("company/{companyId}")]
        public async Task<Results<Ok<IEnumerable<ClaimDto>>, NotFound, ProblemHttpResult>> GetByCompanyId(
            [FromRoute] int companyId, CancellationToken token)
        {
            var result = await _claimService.GetByCompanyIdAsync(companyId, token);

            if (result == null)
            {
                return TypedResults.Problem(ErrorMessage);
            }

            if (!result.Any())
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(result);
        }

        [HttpGet("{ucr}")]
        public async Task<Results<Ok<ClaimDto>, NotFound, ProblemHttpResult>> GetByUcr(
            [FromRoute] string ucr, CancellationToken token)
        {
            var result = await _claimService.GetDetailsAsync(ucr, token);

            if (result == null)
            {
                return TypedResults.Problem(ErrorMessage);
            }

            if (string.IsNullOrEmpty(result.UCR))
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(result);
        }

        [HttpPatch]
        public async Task<Results<Ok, BadRequest, ProblemHttpResult>> Update([FromBody] ClaimUpdateRequestDto claim, CancellationToken token)
        {
            var result = await _claimService.UpdateClaimAsync(claim, token);
            if (result.exception)
            {
                return TypedResults.Problem(ErrorMessage);
            }

            if (result.success)
            {
                return TypedResults.Ok();
            }
            else
            {
                return TypedResults.BadRequest();
            }
        }
    }
}
