# Listing 13-1: The StartAsync method in the MigrationHostedService project

The MigrationHostedService allows us to safely try to migrate the database with delay, when the database can't be opened, the login fails, or the timeout expires (which could all be the result of the container db being in a state of unreadiness)

## The code

```cs
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
        catch (OperationCanceledException ocex)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not connect to {Context} (attempt {Attempt}/{Retries})", typeof(TContext).Name, i + 1, retries);
            await Task.Delay(delay, cancellationToken);
        }
    }
    throw new Exception($"Failed to apply migrations for {typeof(TContext).Name} after {retries} retries.");
}
```  