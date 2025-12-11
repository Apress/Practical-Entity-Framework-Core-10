using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace EF10_InventoryManagerIntegrationTests;

[Collection(nameof(DatabaseTestCollection))]
public class TestGenreRepository : RepoTestBase
{
    public TestGenreRepository(IntegrationTestFixture itf)
        : base(itf) { }

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task GetAllAsync_Returns_All_Genres()
    {
        var repo = new GenreRepository(_itf.Db);

        var all = await repo.GetAllAsync();

        all.Count.ShouldBeGreaterThanOrEqualTo(11); //based on seeddata.cs
        all.ShouldAllBe(c => !string.IsNullOrWhiteSpace(c.GenreName));
    }

    [Fact]
    public async Task GetByIdAsync_Returns_Single_Genre()
    {
        var repo = new GenreRepository(_itf.Db);

        var first = await _itf.Db.Genres.FirstAsync();
        var fetched = await repo.GetByIdAsync(first.Id);

        fetched.ShouldNotBeNull();
        fetched!.Id.ShouldBe(first.Id);
        fetched.GenreName.ShouldBe(first.GenreName);
    }

    [Fact]
    public async Task GetByNameAsync_Finds_By_FilterName()
    {
        var repo = new GenreRepository(_itf.Db);

        var targetName = _itf.Db.Genres.First().GenreName;
        var fetched = await repo.GetByNameAsync(targetName);

        fetched.ShouldNotBeNull();
        fetched!.GenreName.ShouldBe(targetName);
    }

    [Fact]
    public async Task AddAsync_Inserts_New_Genre()
    {
        var repo = new GenreRepository(_itf.Db);

        var toAdd = new Genre { GenreName = "Dystopian", IsActive = true };
        var result = await repo.AddAsync(toAdd);

        result.ShouldBeTrue();
        var reloaded = await repo.GetByNameAsync(toAdd.GenreName);
        reloaded.ShouldNotBeNull();
        reloaded!.GenreName.ShouldBe(toAdd.GenreName);
    }

    [Fact]
    public async Task UpdateAsync_Updates_Existing_Genre()
    {
        var repo = new GenreRepository(_itf.Db);

        var allGenres = await repo.GetAllAsync();
        var existing = allGenres.First();
        existing.GenreName = "UPDATED GENRE NAME";
        var success = await repo.UpdateAsync(existing);

        success.ShouldBeTrue();
        var reloaded = await repo.GetByIdAsync(existing.Id);
        reloaded!.GenreName.ShouldBe("UPDATED GENRE NAME");
    }

    [Fact]
    public async Task DeleteAsync_Removes_Genre()
    {
        var repo = new GenreRepository(_itf.Db);

        var allGenres = await repo.GetAllAsync();
        var existing = allGenres.Last();
        var success = await repo.DeleteAsync(existing.Id);

        success.ShouldBeTrue();
        var exists = await repo.GetByIdAsync(existing.Id) != null;
        exists.ShouldBeFalse();
    }

    [Fact]
    public async Task FindAsync_Predicate_Works()
    {
        var repo = new GenreRepository(_itf.Db);
        var results = await repo.FindAsync(c => c.GenreName.Contains("ovi"));
        results.ShouldNotBeNull();
        results.ShouldAllBe(c => c.GenreName.Contains("ovi"));
    }
}
