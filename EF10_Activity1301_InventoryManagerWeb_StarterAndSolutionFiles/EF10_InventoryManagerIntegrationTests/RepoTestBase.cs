using EF10_InventoryDBLibrary.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryManagerIntegrationTests;

[Collection(nameof(DatabaseTestCollection))]
public abstract class RepoTestBase : IAsyncLifetime
{
    protected readonly IntegrationTestFixture _itf;

    // Default: wrap in transaction
    protected virtual bool EnablePerTestTransaction { get; set; } = true;
    protected RepoTestBase(IntegrationTestFixture itf) => _itf = itf;
    private IDbContextTransaction? _tx;

    public async Task InitializeAsync()
    {
        // Start a transaction before each test
        if (EnablePerTestTransaction)
        {
            _tx = await _itf.Db.Database.BeginTransactionAsync();
        }
        _itf.Db.ChangeTracker.Clear();
    }

    public async Task DisposeAsync()
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
