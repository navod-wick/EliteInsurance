using EliteInsurance.Api.Controllers;
using EliteInsurance.Data;
using EliteInsurance.Data.Dtos;
using EliteInsurance.Data.Entities;
using EliteInsurance.Services.Companies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Moq;

namespace EliteInsurance.Tests;

public class CompanyRequestTests
{
    private readonly DatabaseContext _context = ContextHelper.Create(nameof(CompanyRequestTests));
    private readonly CompanyController _companyController;
    
    
    public CompanyRequestTests()
    {
        var mockLogger = new Mock<ILogger<CompanyService>>();

        var companyService = new CompanyService(mockLogger.Object, _context);
        
        _companyController = new CompanyController(companyService);
        
        AddData();
    }

    [Fact]
    public async Task GetCompanyDetails_Returns_Status200_ForExisting_CompanyId()
    {

        var result = (await _companyController.GetCompanyDetails(1, default)).Result as Ok<CompanyDto>;
        
        Assert.NotNull(result);

        Assert.Equal(200, result.StatusCode);
        
    }

    [Fact]
    public async Task GetCompanyDetails_Returns_Status404_ForNonExisting_CompanyId()
    {

        var result = (await _companyController.GetCompanyDetails(4, default)).Result as NotFound;

        Assert.NotNull(result);

        Assert.Equal(404, result.StatusCode);

    }

    private void AddData()
    {
        _context.Companies.Add(new Company()
        {
            Id = 1,
            Postcode = "LS158RE",
            Name = "Company A",
            Address1 = "7 Elm St",
            Country = "UK",
            Active = true,
            InsuranceEndDate = DateTime.Parse("2024/10/01")
        });
        _context.Companies.Add(new Company()
        {
            Id = 2,
            Postcode = "BD40RX",
            Name = "Company B",
            Address1 = "6 Diagon Alley",
            Country = "UK",
            Active = true,
            InsuranceEndDate = DateTime.Parse("2024/05/01")
        });
        _context.SaveChanges();
    }
}

