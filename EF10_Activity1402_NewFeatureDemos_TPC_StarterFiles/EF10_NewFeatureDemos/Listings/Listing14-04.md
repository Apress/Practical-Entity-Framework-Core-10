# Listing 14-4: Inject into the context and use in the OnConfiguring override (for the default constructor)

Review the code for the injection of the Interceptors

## The code

### Shown in the book 

For the constructor:

```cs
public InventoryDbContext(DbContextOptions<InventoryDbContext> options
                            , LoggingCommandInterceptor loggingInterceptor
                            , SoftDeleteInterceptor softDeleteInterceptor)
    : base(options)
{
    Configure();
    _loggingInterceptor = loggingInterceptor;
    _softDeleteInterceptor = softDeleteInterceptor;
}
```  

### Additional (OnConfiguring Override)

```cs
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        // Load configuration from appsettings.json
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var configuration = builder.Build();
        var connectionString = configuration.GetConnectionString("InventoryDbConnection");

        _softDeleteInterceptor = new SoftDeleteInterceptor();

        // Ensure the following code remains updated to fix the errors:
        var loggerFactory = LoggerFactory.Create(logging =>
        {
            logging.AddConsole(); 
        });
        var logger = loggerFactory.CreateLogger<LoggingCommandInterceptor>();
        _loggingInterceptor = new LoggingCommandInterceptor(logger);

        optionsBuilder.UseSqlServer(connectionString)
            .AddInterceptors(_softDeleteInterceptor)
            .AddInterceptors(_loggingInterceptor);
    }
}
```  