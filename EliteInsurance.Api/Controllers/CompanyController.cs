using EliteInsurance.Data.Dtos;
using EliteInsurance.Services.Companies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EliteInsurance.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("{id}")]
    public async Task<Results<Ok<CompanyDto>, NotFound, ProblemHttpResult>> GetCompanyDetails([FromRoute] int id, CancellationToken token)
    {
        var results = await _companyService.GetByIdAsync(id, token);

        if (results == null)
        {
            return TypedResults.Problem("There was an error when handling your request please contact system admin");
        }

        if (results.CompanyId == -1)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(results);
    }
}

