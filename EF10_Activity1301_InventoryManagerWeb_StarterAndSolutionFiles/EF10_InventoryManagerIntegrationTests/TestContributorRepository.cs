using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace EF10_InventoryManagerIntegrationTests;

[Collection(nameof(DatabaseTestCollection))]
public class TestContributorRepository : RepoTestBase
{
    public TestContributorRepository(IntegrationTestFixture itf)
        : base(itf) { }

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task GetAllAsync_Returns_All_Contributors()
    {
        var repo = new ContributorRepository(_itf.Db);

        var all = await repo.GetAllAsync();

        all.Count.ShouldBeGreaterThanOrEqualTo(27); //based on seeddata.cs
        all.ShouldAllBe(c => !string.IsNullOrWhiteSpace(c.ContributorName));
    }

    [Fact]
    public async Task GetByIdAsync_Returns_Single_Contributor()
    {
        var repo = new ContributorRepository(_itf.Db);

        var first = await _itf.Db.Contributors.FirstAsync();
        var fetched = await repo.GetByIdAsync(first.Id);

        fetched.ShouldNotBeNull();
        fetched!.Id.ShouldBe(first.Id);
        fetched.ContributorName.ShouldBe(first.ContributorName);
    }

    [Fact]
    public async Task GetByNameAsync_Finds_By_FilterName()
    {
        var repo = new ContributorRepository(_itf.Db);

        var targetName = _itf.Db.Contributors.First().ContributorName;
        var fetched = await repo.GetByNameAsync(targetName);

        fetched.ShouldNotBeNull();
        fetched!.ContributorName.ShouldBe(targetName);
    }

    [Fact]
    public async Task AddAsync_Inserts_New_Contributor()
    {
        var repo = new ContributorRepository(_itf.Db);

        var toAdd = new Contributor { ContributorName = "Wil Smith", Description = "The Fresh Prince", IsActive = true };
        var result = await repo.AddAsync(toAdd);

        result.ShouldBeTrue();
        var reloaded = await repo.GetByNameAsync(toAdd.ContributorName);
        reloaded.ShouldNotBeNull();
        reloaded!.ContributorName.ShouldBe(toAdd.ContributorName);
        reloaded.Description.ShouldBe(toAdd.Description);
    }

    [Fact]
    public async Task UpdateAsync_Updates_Existing_Contributor()
    {
        var repo = new ContributorRepository(_itf.Db);

        var allContributors = await repo.GetAllAsync();
        var existing = allContributors.First();
        existing.ContributorName = "UPDATED CONTRIBUTOR";
        existing.Description = "Updated Description";
        var success = await repo.UpdateAsync(existing);
        success.ShouldBeTrue();

        var reloaded = await repo.GetByIdAsync(existing.Id);
        reloaded!.ContributorName.ShouldBe("UPDATED CONTRIBUTOR");
        reloaded.Description.ShouldBe("Updated Description");
    }

    [Fact]
    public async Task DeleteAsync_Removes_Contributor()
    {
        var repo = new ContributorRepository(_itf.Db);

        var allContributors = await repo.GetAllAsync();
        var existing = allContributors.Last();
        var success = await repo.DeleteAsync(existing.Id);

        success.ShouldBeTrue();
        var exists = await repo.GetByIdAsync(existing.Id) != null;
        exists.ShouldBeFalse();
    }

    [Fact]
    public async Task FindAsync_Predicate_Works()
    {
        var repo = new ContributorRepository(_itf.Db);
        var results = await repo.FindAsync(c => c.ContributorName.Contains("John"));
        results.ShouldNotBeNull();
        results.ShouldAllBe(c => c.ContributorName.Contains("John"));
    }

    /*
     * Task<int> AddRangeAsync(List<Contributor> contributors); // Custom method to add range of contributors

    Task<Contributor?> GetContributorByNameWithItemsAsync(string name);*/

    [Fact]
    public async Task AddRangeAsync_Adds_Multiple_Contributors()
    {
        var repo = new ContributorRepository(_itf.Db);
        var contributorsToAdd = new List<Contributor>
        {
            new Contributor { ContributorName = "Alice Smith", Description = "Author", IsActive = true },
            new Contributor { ContributorName = "Bob Johnson", Description = "Editor", IsActive = true }
        };
        var resultCount = await repo.AddRangeAsync(contributorsToAdd);
        resultCount.ShouldBe(2); // Expecting 2 contributors to be added
        foreach (var contributor in contributorsToAdd)
        {
            var reloaded = await repo.GetByNameAsync(contributor.ContributorName);
            reloaded.ShouldNotBeNull();
            reloaded!.ContributorName.ShouldBe(contributor.ContributorName);
            reloaded.Description.ShouldBe(contributor.Description);
        }
    }

    [Fact]
    public async Task GetContributorByNameWithItemsAsync_Returns_Contributor_With_Items()
    {
        var repo = new ContributorRepository(_itf.Db);
        var contributorName = "George Lucas";
        var contributor = await repo.GetContributorByNameWithItemsAsync(contributorName);
        contributor.ShouldNotBeNull();
        contributor!.ContributorName.ShouldBe(contributorName);
        contributor.ItemContributors.ShouldNotBeEmpty();
        foreach (var itemContributor in contributor.ItemContributors)
        {
            itemContributor.Item.ShouldNotBeNull();
            itemContributor.Item.Name.ShouldNotBeNullOrEmpty();
        }
    }
}
