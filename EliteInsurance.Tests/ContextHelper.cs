using EliteInsurance.Data;
using Microsoft.EntityFrameworkCore;

namespace EliteInsurance.Tests;

public static class ContextHelper
{
    public static DatabaseContext Create(string databaseName)
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName)
            .Options;

        var context = new DatabaseContext(options);

        context.Database.EnsureDeleted();

        return context;
    }
}

