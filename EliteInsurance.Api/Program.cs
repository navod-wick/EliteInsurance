using EliteInsurance.Data;
using EliteInsurance.Services.Claims;
using EliteInsurance.Services.Companies;
using Microsoft.EntityFrameworkCore;
using Vernou.Swashbuckle.HttpResultsAdapter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Inject DB Context
var connectionString = builder.Configuration.GetConnectionString("ApplicationConnString");

if (string.IsNullOrEmpty(connectionString))
{
    throw new ApplicationException("Missing connection string, please check settings file");
}

builder.Services.AddDbContext<DatabaseContext>(o =>
    o.UseSqlServer(connectionString));

//Inject services
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IClaimService, ClaimService>();

builder.Services.AddEndpointsApiExplorer();

//To display all possible return types in Swagger Doc
builder.Services.AddSwaggerGen(o => o.OperationFilter<HttpResultsOperationFilter>());

builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
