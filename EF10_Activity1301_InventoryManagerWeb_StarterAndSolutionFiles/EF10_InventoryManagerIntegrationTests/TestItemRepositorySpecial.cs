using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryManagerIntegrationTests;

public class TestItemRepositorySpecial : RepoTestBase
{
    public TestItemRepositorySpecial(IntegrationTestFixture itf)
        : base(itf)
    {
        //Listing 12-46
        EnablePerTestTransaction = false; // Disable per-test transaction for this test class
    }

    [Fact]
    public async Task TestBulkLoadItemDataAsyncRollback()
    {
        //Listing 12-47
        var repo = new ItemRepository(_itf.Db);
        var beforeItems = await repo.GetAllAsync();
        var itemCount = beforeItems.Count();
        var item1 = new Item() { Name = "Bulk Item 1", CategoryId = 1, Description = "Bulk Item 1 Description", IsActive = true, Genres = new List<Genre>() };
        var item2 = new Item() { Name = "Bulk Item 2", CategoryId = 2, Description = "Bulk Item 2 Description", IsActive = true, Genres = new List<Genre>() };

        var contributorDetails1 = new Dictionary<int, string>();
        contributorDetails1.Add(1, "Actor");

        var contributorDetails2 = new Dictionary<int, string>();
        contributorDetails2.Add(1, "Musician");

        //item 1 should add
        //item 2 should fail due to invalid genre ids, so nothing should be added
        var items = new List<ParsedItemDataDTO>
        {
            new ParsedItemDataDTO { Item = item1, ContributorData = contributorDetails1, GenreIds = new List<int>() {1, 2, 3 } },
            new ParsedItemDataDTO { Item = item2, ContributorData = contributorDetails2, GenreIds = new List<int>() {75, 99, 131 } }
        };

        var success = await repo.BulkLoadItemDataAsync(items);
        success.ShouldBeFalse(); // Should fail due to invalid genre ids, and rollback
        var afterItems = await repo.GetAllAsync();
        afterItems.Count().ShouldBe(itemCount); // No new items should be added
    }
    
    //Do not run this test as it will commit changes to the database and affect other tests
    //[Fact]
    //public async Task TestBulkLoadItemDataAsyncCommit()
    //{
    //    UsePerTestTransaction = false;
    //    var repo = new ItemRepository(_itf.Db);
    //    var beforeItems = await repo.GetAllAsync();
    //    var itemCount = beforeItems.Count();
    //    var item1 = new Item() { Name = "Bulk Item 1", CategoryId = 1, Description = "Bulk Item 1 Description", IsActive = true, Genres = new List<Genre>() };
    //    var item2 = new Item() { Name = "Bulk Item 2", CategoryId = 2, Description = "Bulk Item 2 Description", IsActive = true, Genres = new List<Genre>() };

    //    var contributorDetails1 = new Dictionary<int, string>();
    //    contributorDetails1.Add(1, "Actor");

    //    var contributorDetails2 = new Dictionary<int, string>();
    //    contributorDetails2.Add(1, "Author");

    //    //item 1 should add
    //    //item 2 should add 
    //    var items = new List<ParsedItemDataDTO>
    //    {
    //        new ParsedItemDataDTO { Item = item1, ContributorData = contributorDetails1, GenreIds = new List<int>() {1, 2, 3 } },
    //        new ParsedItemDataDTO { Item = item2, ContributorData = contributorDetails2, GenreIds = new List<int>() {2, 3, 4 } }
    //    };

    //    var success = await repo.BulkLoadItemDataAsync(items);
    //    success.ShouldBeTrue(); // Should fail due to invalid genre ids, and rollback
    //    var afterItems = await repo.GetAllAsync();
    //    afterItems.Count().ShouldBe(itemCount + 2); // No new items should be added
    //}
}
