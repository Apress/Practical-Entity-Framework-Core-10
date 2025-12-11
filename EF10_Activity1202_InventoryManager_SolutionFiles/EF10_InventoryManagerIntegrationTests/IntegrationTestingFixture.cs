using DotNet.Testcontainers.Builders;
using EF10_InventoryDBLibrary;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Testcontainers.MsSql;

namespace EF10_InventoryManagerIntegrationTests;

[CollectionDefinition(nameof(DatabaseTestCollection), DisableParallelization = true)]
public class DatabaseTestCollection : ICollectionFixture<IntegrationTestFixture> { }

public sealed class IntegrationTestFixture : IAsyncLifetime
{
    private readonly MsSqlContainer _container =
    new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest") // X64 compatible image
        //.WithImage("mcr.microsoft.com/azure-sql-edge:latest")  // ARM64 compatible image
        .WithPassword("Password#123!")
        .WithWaitStrategy(Wait.ForUnixContainer().UntilInternalTcpPortIsAvailable(1433))
        .Build();

    public InventoryDbContext Db { get; private set; } = null!;
    public string ConnectionString { get; private set; } = string.Empty;
    private DbConnection _connection = null!;

    public async ValueTask InitializeAsync()
    {
        // 1) Start SQL Server in Docker
        await _container.StartAsync();

        // 2) Build EF Core DbContext pointing at the container DB
        ConnectionString = _container.GetConnectionString();
        var options = new DbContextOptionsBuilder<InventoryDbContext>()
            .UseSqlServer(ConnectionString)
            .EnableSensitiveDataLogging()
            .Options;

        Db = new InventoryDbContext(options);

        // 3) Create schema (or run migrations)
        // If you have migrations, prefer Migrate(); otherwise EnsureCreated();
        await Db.Database.MigrateAsync();

        // Optional: open and keep a shared connection for the lifetime of the fixture

        _connection = Db.Database.GetDbConnection();
        await _connection.OpenAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (_connection is not null)
            await _connection.CloseAsync();

        await _container.DisposeAsync();
    }
}

