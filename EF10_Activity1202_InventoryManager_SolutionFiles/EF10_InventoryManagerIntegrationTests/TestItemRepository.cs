using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace EF10_InventoryManagerIntegrationTests;

[Collection(nameof(DatabaseTestCollection))]
public class TestItemRepository : RepoTestBase
{
    public TestItemRepository(IntegrationTestFixture itf)
        : base(itf) { }

    [Fact]
    public async Task GetAllAsync_Returns_All_Items()
    {
        //Listing 12-34
        var repo = new ItemRepository(_itf.Db);
        var all = await repo.GetAllAsync();
        all.Count.ShouldBeGreaterThanOrEqualTo(11); //based on seeddata.cs
        all.ShouldAllBe(c => !string.IsNullOrWhiteSpace(c.Name));
    }

    [Fact]
    public async Task GetByIdAsync_Returns_Single_Item()
    {
        //Listing 12-35 - Get by Id
        var repo = new ItemRepository(_itf.Db);

        var first = await _itf.Db.Items.FirstAsync();
        var fetched = await repo.GetByIdAsync(first.Id);

        fetched.ShouldNotBeNull();
        fetched!.Id.ShouldBe(first.Id);
        fetched.Name.ShouldBe(first.Name);
    }

    [Fact]
    public async Task GetByNameAsync_Finds_By_FilterName()
    {
        //Listing 12-36 - Get Item By Name Async
        var repo = new ItemRepository(_itf.Db);
        var first = await _itf.Db.Items.FirstAsync();
        var fetched = await repo.GetByNameAsync(first.Name);
        fetched.ShouldNotBeNull();
        fetched!.Id.ShouldBe(first.Id);
        fetched.Name.ShouldBe(first.Name);
    }

    [Fact]
    public async Task GetItemByNameWithGenreByNameAsync_Returns_Item_With_Specific_Genre()
    {
        //Listing 12-37: Get Item by Name and Genre Name
        var repo = new ItemRepository(_itf.Db);
        var itemName = "The Shawshank Redemption";
        var genreName = "Drama";
        var item = await repo.GetItemByNameWithGenreByNameAsync(itemName, genreName);
        item.ShouldNotBeNull();
        item!.Name.ShouldBe(itemName);
        item.Genres.ShouldNotBeNull();
        item.Genres.ShouldContain(g => g.GenreName == genreName);
    }

    [Fact]
    public async Task GetItemsByFilterAsync_Returns_Filtered_Items()
    {
        //Listing 12-38 - Get Items By Filter
        var repo = new ItemRepository(_itf.Db);
        var filter = "The"; // Example filter
        var items = await repo.GetItemsByFilterAsync(filter);
        items.ShouldNotBeNull();
        items.ShouldAllBe(i => i.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task TestGetAllItemsWithCategoryAsync()
    {
        //Listing 12-39 - Get All items with their category included
        var repo = new ItemRepository(_itf.Db);
        var itemsWithCategory = await repo.GetAllItemsWithCategoryAsync();
        itemsWithCategory.ShouldNotBeNull();
        itemsWithCategory.ShouldAllBe(i => i.Category != null);
        itemsWithCategory.Count.ShouldBeGreaterThanOrEqualTo(50); // Based on seed data
    }

    [Fact]
    public async Task FindAsync_Predicate_Works()
    {
        //Listing 12-40 - Find Async
        var repo = new ItemRepository(_itf.Db);
        var results = await repo.FindAsync(c => c.Name.Contains("ovi"));
        results.ShouldNotBeNull();
        results.ShouldAllBe(c => c.Name.Contains("ovi"));
    }

    [Fact]
    public async Task AddAsync_Inserts_New_Item()
    {
        //Listing 12-41: Arrange and Act for AddAsync
        var repo = new ItemRepository(_itf.Db);
        var categoryRepo = new CategoryRepository(_itf.Db);
        var genreRepo = new GenreRepository(_itf.Db);
        var contributorRepo = new ContributorRepository(_itf.Db);

        var movieCategory = await categoryRepo.GetByNameAsync("Movie");
        var genres = await genreRepo.GetAllAsync();
        var contributors = await contributorRepo.GetAllAsync();
        var genre1 = genres
            .SingleOrDefault(x => x.GenreName == "Drama") ?? genres.FirstOrDefault();
        var genre2 = genres
            .SingleOrDefault(x => x.GenreName == "Thriller") ?? genres.LastOrDefault();
        var contributor1 = contributors
            .SingleOrDefault(x => x.ContributorName == "Christopher Nolan")
            ?? contributors.FirstOrDefault();
        var contributor2 = contributors
            .SingleOrDefault(x => x.ContributorName == "Chrisitan Bale")
            ?? contributors.LastOrDefault();
        var itemContributors = new List<ItemContributor>
        {
            new ItemContributor { Contributor = contributor1
                , ContributorType = ContributorType.Director },
            new ItemContributor { Contributor = contributor2
                , ContributorType = ContributorType.Actor }
        };
        var Genres = new List<Genre> { genre1, genre2 };

        var toAdd = new Item
        {
            Name = "The Prestige"
            ,
            CategoryId = movieCategory?.Id ?? 1
            ,
            ItemContributors = itemContributors
            ,
            Genres = Genres
            ,
            Description = "A mind-bending thriller by Christopher Nolan"
            ,
            IsActive = true
        };
        var result = await repo.AddAsync(toAdd);

        //TODO:Listing 12-42
        result.ShouldBeTrue();
        var reloaded = await repo.GetByNameAsync(toAdd.Name);
        reloaded.ShouldNotBeNull();
        reloaded!.Name.ShouldBe(toAdd.Name);

        //tests Task<Item?> GetItemByNameWithCategoryAsync(string name);
        var itemDetail = await repo.GetItemByNameWithCategoryAsync(toAdd.Name);
        itemDetail.ShouldNotBeNull();
        itemDetail!.Category.ShouldNotBeNull();
        itemDetail!.Category.CategoryName.ShouldBe(movieCategory?.CategoryName);

        //tests Task<Item?> GetItemByNameWithGenreAsync(string name);
        itemDetail = await repo.GetItemByNameWithGenreAsync(toAdd.Name);
        itemDetail.ShouldNotBeNull();
        itemDetail!.Genres.ShouldNotBeNull();
        itemDetail!.Genres.Count.ShouldBeGreaterThanOrEqualTo(2);
        itemDetail!.Genres.ShouldContain(g => g.GenreName == genre1.GenreName);
        itemDetail!.Genres.ShouldContain(g => g.GenreName == genre2.GenreName);
    }

    [Fact]
    public async Task UpdateAsync_Updates_Existing_Item()
    {
        //Listing 12-43: Testing Update an Item
        var repo = new ItemRepository(_itf.Db);

        var allItems = await repo.GetAllAsync();
        var existing = allItems.First();
        existing.Name = "UPDATED ITEM NAME";
        var success = await repo.UpdateAsync(existing);

        success.ShouldBeTrue();
        var reloaded = await repo.GetByIdAsync(existing.Id);
        reloaded!.Name.ShouldBe("UPDATED ITEM NAME");
    }

    [Fact]
    public async Task UpdateRangeAsync_Updates_Multiple_Items()
    {
        //Listing 12-44 - update range
        var repo = new ItemRepository(_itf.Db);
        var allItems = await repo.GetAllAsync();
        allItems.ShouldNotBeNull();
        allItems.Count.ShouldBeGreaterThan(0);
        // Modify items for update
        foreach (var item in allItems)
        {
            item.Description = $"{item.Description} - Updated {DateTime.UtcNow}";
            item.IsOnSale = true; // Example modification
        }
        var result = await repo.UpdateRangeAsync(allItems);
        result.ShouldBeGreaterThan(0); // Should return number of updated records
                                       // Verify updates
        foreach (var item in allItems)
        {
            var updatedItem = await repo.GetByIdAsync(item.Id);
            updatedItem!.Description?.ShouldContain("Updated");
            updatedItem!.IsOnSale.ShouldBeTrue();

        }
    }

    [Fact]
    public async Task DeleteAsync_Removes_Item()
    {
        //Listing 12-45: Delete Async
        var repo = new ItemRepository(_itf.Db);

        var allItems = await repo.GetAllAsync();
        var existing = allItems.Last();
        var success = await repo.DeleteAsync(existing.Id);

        success.ShouldBeTrue();
        var exists = await repo.GetByIdAsync(existing.Id) != null;
        exists.ShouldBeFalse();
    }
}

