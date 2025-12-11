using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagerWeb.Data;

public class MigrationHostedService<TContext> : IHostedService where TContext : DbContext
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<MigrationHostedService<TContext>> _logger;

    public MigrationHostedService(IServiceProvider serviceProvider, ILogger<MigrationHostedService<TContext>> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var retries = 10;
        var delay = TimeSpan.FromSeconds(15);

        for (var i = 0; i < retries; i++)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<TContext>();
                await db.Database.MigrateAsync(cancellationToken);

                _logger.LogInformation("Database migrations applied for {Context}", typeof(TContext).Name);
                return;
            }
            catch (SqlException ex) when (ex.Number == 4060 || ex.Number == 18456 || ex.Number == -2)
            {
                // 4060 = Cannot open database
                // 18456 = Login failed
                // -2    = Timeout expired
                _logger.LogWarning("Database not ready, retrying... {Message}", ex.Message);
                await Task.Delay(delay, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Could not connect to {Context} (attempt {Attempt}/{Retries})", typeof(TContext).Name, i + 1, retries);
                await Task.Delay(delay, cancellationToken);
            }
        }

        throw new Exception($"Failed to apply migrations for {typeof(TContext).Name} after {retries} retries.");
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

