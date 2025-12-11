# Listing 04-01: Load the connection string from an AppSettings file

The listing for loading code from a local appsettings.json (or secrets.json) file

## The code

The code as shown in the book:

```cs
// other code … 

// Configure EF
var optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
optionsBuilder.UseSqlServer(connectionString);

return new InventoryDbContext(optionsBuilder.Options);
```  

## Completeness

The code as it exists in the InventoryDbContext.cs class file

```cs
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
```  