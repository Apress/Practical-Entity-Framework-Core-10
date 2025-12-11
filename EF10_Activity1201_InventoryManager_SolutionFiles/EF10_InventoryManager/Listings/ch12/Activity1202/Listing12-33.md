# Listing 12-33: The RepoTestBase Dispose Async method

This dispose method will roll back any transaction that was in process and also clear the ChangeTracker.

This operation is incredibly important because now you can use the transaction to prevent the underlying data changes for things like adding or removing from persisting across test runs.

The reset of the ChangeTracker ensures that the context is back to the default state with no modifications at the start of every test run.

## The Code

```cs
// the code for InitializeAsync (shown in Listing 12-32)

public async ValueTask DisposeAsync()
{
    // Nuke all changes from the test
    if (_tx is not null)
    {
        await _tx.RollbackAsync();
        await _tx.DisposeAsync();
    }
    _itf.Db.ChangeTracker.Clear();
}
``` 

## Full code

```cs
using Microsoft.EntityFrameworkCore.Storage;

namespace EF10_InventoryManagerIntegrationTests;

[Collection(nameof(DatabaseTestCollection))]
public abstract class RepoTestBase : IAsyncLifetime
{
    protected readonly IntegrationTestFixture _itf;

    // Default: wrap in transaction
    protected virtual bool EnablePerTestTransaction { get; set; } = true;
    protected RepoTestBase(IntegrationTestFixture itf) => _itf = itf;
    private IDbContextTransaction? _tx;

    public async ValueTask InitializeAsync()
    {
        // Start a transaction before each test
        if (EnablePerTestTransaction)
        {
            _tx = await _itf.Db.Database.BeginTransactionAsync();
        }
        _itf.Db.ChangeTracker.Clear();
    }

    public async ValueTask DisposeAsync()
    {
        // Nuke all changes from the test
        if (_tx is not null)
        {
            await _tx.RollbackAsync();
            await _tx.DisposeAsync();
        }
        _itf.Db.ChangeTracker.Clear();
    }
}
```  