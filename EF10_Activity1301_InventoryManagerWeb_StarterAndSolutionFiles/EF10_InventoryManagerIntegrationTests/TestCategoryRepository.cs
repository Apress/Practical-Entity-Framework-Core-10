using DotNet.Testcontainers.Builders;
using EF10_InventoryDataLayer;
using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Testcontainers.MsSql;

namespace EF10_InventoryManagerIntegrationTests;


[Collection(nameof(DatabaseTestCollection))]
public class TestCategoryRepository : RepoTestBase
{
    public TestCategoryRepository(IntegrationTestFixture itf)
        : base(itf) { }

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task GetAllAsync_Returns_All_Categories()
    {
        var repo = new CategoryRepository(_itf.Db);

        var all = await repo.GetAllAsync();

        all.Count.ShouldBeGreaterThanOrEqualTo(4); //based on seeddata.cs
        all.ShouldAllBe(c => !string.IsNullOrWhiteSpace(c.CategoryName));
    }

    [Fact]
    public async Task GetByIdAsync_Returns_Single_Category()
    {
        var repo = new CategoryRepository(_itf.Db);

        var first = await _itf.Db.Categories.FirstAsync();
        var fetched = await repo.GetByIdAsync(first.Id);

        fetched.ShouldNotBeNull();
        fetched!.Id.ShouldBe(first.Id);
        fetched.CategoryName.ShouldBe(first.CategoryName);
    }

    [Fact]
    public async Task GetByNameAsync_Finds_By_FilterName()
    {
        var repo = new CategoryRepository(_itf.Db);

        var targetName = _itf.Db.Categories.First().CategoryName;
        var fetched = await repo.GetByNameAsync(targetName);

        fetched.ShouldNotBeNull();
        fetched!.CategoryName.ShouldBe(targetName);
    }

    [Fact]
    public async Task AddAsync_Inserts_New_Category()
    {
        var repo = new CategoryRepository(_itf.Db);

        var toAdd = new Category { CategoryName = "Board Game", Description = "Tabletop", IsActive = true };
        var result = await repo.AddAsync(toAdd);

        result.ShouldBeTrue();
        var reloaded = await repo.GetByNameAsync(toAdd.CategoryName);
        reloaded.ShouldNotBeNull();
        reloaded!.CategoryName.ShouldBe(toAdd.CategoryName);
    }

    [Fact]
    public async Task UpdateAsync_Updates_Existing_Category()
    {
        var repo = new CategoryRepository(_itf.Db);

        var allCategories = await repo.GetAllAsync();
        var existing = allCategories.First();
        existing.Description = "UPDATED";
        var success = await repo.UpdateAsync(existing);

        success.ShouldBeTrue();
        var reloaded = await repo.GetByIdAsync(existing.Id);
        reloaded!.Description.ShouldBe("UPDATED");
    }

    [Fact]
    public async Task DeleteAsync_Removes_Category()
    {
        var repo = new CategoryRepository(_itf.Db);

        var allCategories = await repo.GetAllAsync();
        var existing = allCategories.Last();
        var success = await repo.DeleteAsync(existing.Id);

        success.ShouldBeTrue();
        var exists = await repo.GetByIdAsync(existing.Id) != null;
        exists.ShouldBeFalse();
    }

    [Fact]
    public async Task FindAsync_Predicate_Works()
    {
        var repo = new CategoryRepository(_itf.Db);
        var results = await repo.FindAsync(c => c.CategoryName.Contains("ovi"));
        results.ShouldNotBeNull();
        results.ShouldAllBe(c => c.CategoryName.Contains("ovi"));
    }
}
