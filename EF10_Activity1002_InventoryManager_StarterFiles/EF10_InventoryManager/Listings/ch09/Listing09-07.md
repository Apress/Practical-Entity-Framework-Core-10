# Listing 9-7: Injecting the mapper for dependency injection use in other places in the program

Using DI and services, create the service for AutoMapper only once.

## The Code

Place this code in the Program.cs file to configure the AutoMapper dependency injection.  

```cs
services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
```  

>**Note**: this code is added to the `ConfigureServices((context, services) => ...` implementation in Program.cs

For clarity, the whole section is shown below:

```cs
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
            config.AddUserSecrets<Program>();
        })
        .ConfigureServices((context, services) =>
        {
            var connectionString = context.Configuration.GetConnectionString("InventoryDbConnection");

            /* comment the following if you want to use lazy loading proxies */
            services.AddDbContext<InventoryDbContext>(options =>
                options.UseSqlServer(connectionString));

            //*** Uncomment the following lines if you want to enable lazy loading proxies ***/
            /*
            services.AddDbContext<InventoryDbContext>(options =>
                options.UseSqlServer(connectionString)
                    .UseLazyLoadingProxies()); 
            */

            //Automapper
            services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

            // Add other services here if needed
            services.AddTransient<Application>();
        })
        .Build();

    using var scope = host.Services.CreateScope();
    var app = scope.ServiceProvider.GetRequiredService<Application>();
    await app.DoWork();
}
```  

>**Note:** Line 49 is the new code.
