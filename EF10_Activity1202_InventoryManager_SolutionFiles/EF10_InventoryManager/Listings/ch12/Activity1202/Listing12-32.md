# Listing 12-32: The start of the RepoTestBase class

The RepoTestBase class sets the foundation for all tests to have an option to opt-out of using a wrapping transaction.

All but one of the tests you write will use the transaction approach.

This allows you to avoid having to rebuild or spin up a new database for every test without having to worry about managing the state of the database.


## The Code

```cs
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

    //...more code (see Listing 12-33)
```

```cs
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

    //listing 12-33:
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