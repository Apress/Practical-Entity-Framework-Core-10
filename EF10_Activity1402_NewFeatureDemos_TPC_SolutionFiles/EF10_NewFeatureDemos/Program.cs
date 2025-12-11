using EF10_NewFeaturesDbLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace EF10_NewFeatureDemos;

public class Program
{
    public static async Task Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";
        //TODO: Toggle this to turn interceptors on or off after running initial migrations (update database)
        var useInterceptors = Environment.GetEnvironmentVariable("USE_INTERCEPTORS") ?? "false";
        var logToConsole = Environment.GetEnvironmentVariable("LOG_TO_CONSOLE") ?? "false";
        var appSettingsFile = string.IsNullOrWhiteSpace(environment)
            ? "appsettings.json"
            : $"appsettings.{environment}.json";

        var ts = DateTime.Now.ToString("yyyyMMddHHmmss");
        var directory = @"C:\Logs";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        var logPath = $@"{directory}\logfile_{ts}.txt"; // Adjust the path as needed

        var loggerConfig = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(logPath, rollingInterval: RollingInterval.Day);

        if (logToConsole.Equals("true", StringComparison.OrdinalIgnoreCase))
        {
            loggerConfig = loggerConfig.WriteTo.Console();
        }

        Log.Logger = loggerConfig.CreateLogger();

        // Banner for current config
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Environment:     {environment}");
        Console.WriteLine($"Interceptors:    {(useInterceptors.Equals("true", StringComparison.OrdinalIgnoreCase) ? "ON" : "OFF")}");
        Console.WriteLine($"Console logging: {(logToConsole.Equals("true", StringComparison.OrdinalIgnoreCase) ? "ON" : "OFF")}");
        Console.WriteLine($"Log file:        {logPath}");
        Console.WriteLine("--------------------------------------------------");

        var host = Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddJsonFile(appSettingsFile, optional: true);
                config.AddEnvironmentVariables();
                config.AddUserSecrets<Program>();
            })
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("InventoryDbConnection");
                services.AddScoped<LoggingCommandInterceptor>();
                services.AddScoped<SoftDeleteInterceptor>();

                services.AddDbContext<InventoryDbContext>((serviceProvider, options) =>
                {
                    var loggingInterceptor = serviceProvider.GetRequiredService<LoggingCommandInterceptor>();
                    var softDeleteInterceptor = serviceProvider.GetRequiredService<SoftDeleteInterceptor>();

                    //Turn on with the flag at the top or by setting the environment variable USE_INTERCEPTORS=true
                    if (useInterceptors.Equals("true", StringComparison.OrdinalIgnoreCase))
                    {
                        options.UseSqlServer(connectionString)
                            .AddInterceptors(loggingInterceptor, softDeleteInterceptor);
                    }
                    else
                    {
                        options.UseSqlServer(connectionString);
                    }
                });

                // Add other services here if needed
                services.AddTransient<Application>();
            })
            .Build();

        using var scope = host.Services.CreateScope();
        var app = scope.ServiceProvider.GetRequiredService<Application>();
        await app.DoWork();
        Log.CloseAndFlush();
    }
}
