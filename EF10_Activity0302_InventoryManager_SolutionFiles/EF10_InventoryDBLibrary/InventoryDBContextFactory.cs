using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EF10_InventoryDBLibrary;

public class InventoryDbContextFactory : IDesignTimeDbContextFactory<InventoryDbContext>
{
    public InventoryDbContext CreateDbContext(string[] args)
    {
        // Determine environment (default to "Development" if not set)
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        var appSettingsFile = string.IsNullOrWhiteSpace(environment)
            ? "appsettings.json"
            : $"appsettings.{environment}.json";

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile(appSettingsFile, optional: true)
            .AddUserSecrets<InventoryDbContextFactory>() 
            .AddEnvironmentVariables()
            .Build();

        // Read connection string
        var connectionString = config.GetConnectionString("InventoryDbConnection");

        // Configure EF
        var optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new InventoryDbContext(optionsBuilder.Options);
    }
}