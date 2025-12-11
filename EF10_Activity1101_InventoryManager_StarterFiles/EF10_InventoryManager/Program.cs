using System.Reflection;
using EF10_InventoryDataLayer;
using EF10_InventoryDBLibrary;
using EF10_InventoryServiceLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EF10_InventoryManager;

public class Program
{
    public static async Task Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        var appSettingsFile = string.IsNullOrWhiteSpace(environment)
            ? "appsettings.json"
            : $"appsettings.{environment}.json";

        var host = Host.CreateDefaultBuilder(args)
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

                /* comment the following if you want to use lazy loading proxies */
                /* */
                services.AddDbContext<InventoryDbContext>(options =>
                    options.UseSqlServer(connectionString));

                //services added for Chapter 11 activities
                services.AddScoped<IItemService, ItemService>();
                services.AddScoped<ICategoryService, CategoryService>();
                services.AddScoped<IContributorService, ContributorService>();
                services.AddScoped<IGenreService, GenreService>();
                services.AddScoped<IItemRepository, ItemRepository>();
                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddScoped<IContributorRepository, ContributorRepository>();
                services.AddScoped<IGenreRepository, GenreRepository>();

                //*** Uncomment the following lines if you want to enable lazy loading proxies ***/
                /* 
                services.AddDbContext<InventoryDbContext>(options =>
                    options.UseSqlServer(connectionString)
                        .UseLazyLoadingProxies()); 
                */

                //Listing 9-7: Injecting Automapper
                services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

                // Add other services here if needed
                services.AddTransient<Application>();
            })
            .Build();

        using var scope = host.Services.CreateScope();
        var app = scope.ServiceProvider.GetRequiredService<Application>();
        await app.DoWork();
    }
}

