using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_AWDBLibrary;

public class AdventureWorksContextFactory : IDesignTimeDbContextFactory<AdventureWorksContext>
{
    public AdventureWorksContext CreateDbContext(string[] args)
    {
        // Determine environment (default to "Production" if not set)
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;
        var appSettingsFile = string.IsNullOrWhiteSpace(environment)
            ? "appsettings.json"
            : $"appsettings.{environment}.json";

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(appSettingsFile, optional: false)
            .Build();

        // Read connection string
        var connectionString = config.GetConnectionString("AWDbConnection");

        // Configure EF
        var optionsBuilder = new DbContextOptionsBuilder<AdventureWorksContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new AdventureWorksContext(optionsBuilder.Options);
    }
}