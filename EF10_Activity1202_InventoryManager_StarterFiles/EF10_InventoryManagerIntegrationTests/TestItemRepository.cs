namespace EF10_InventoryManagerIntegrationTests;

[Collection(nameof(DatabaseTestCollection))]
public class TestItemRepository : RepoTestBase
{
    public TestItemRepository(IntegrationTestFixture itf)
        : base(itf) { }

    [Fact]
    public async Task GetAllAsync_Returns_All_Items()
    {
        //TODO: Listing 12-34
        Assert.Fail("GetAllAsync_Returns_All_Items is not implemented yet.");
    }

    [Fact]
    public async Task GetByIdAsync_Returns_Single_Item()
    {
        //TODO: Listing 12-35
        Assert.Fail("GetByIdAsync_Returns_Single_Item is not implemented yet.");
    }

    [Fact]
    public async Task GetByNameAsync_Finds_By_FilterName()
    {
        //TODO: Listing 12-36
        Assert.Fail("GetByNameAsync_Finds_By_FilterName is not implemented yet.");
    }

    [Fact]
    public async Task GetItemByNameWithGenreByNameAsync_Returns_Item_With_Specific_Genre()
    {
        //TODO: Listing 12-37
        Assert.Fail("GetItemByNameWithGenreByNameAsync_Returns_Item_With_Specific_Genre is not implemented yet.");
    }

    [Fact]
    public async Task GetItemsByFilterAsync_Returns_Filtered_Items()
    {
        //TODO: Listing 12-38 - Get Items By Filter
        Assert.Fail("GetItemsByFilterAsync_Returns_Filtered_Items is not implemented yet.");
    }

    [Fact]
    public async Task TestGetAllItemsWithCategoryAsync()
    {
        //Listing 12-39 - Get Items With Category information
        Assert.Fail("TestGetAllItemsWithCategoryAsync is not implemented yet.");
    }

    [Fact]
    public async Task FindAsync_Predicate_Works()
    {
        //TODO: Listing 12-40
        Assert.Fail("FindAsync_Predicate_Works is not implemented yet.");
    }

    [Fact]
    public async Task AddAsync_Inserts_New_Item()
    {
        //TODO: Listing 12-41
        //add the first part of the test here

        //TODO:Listing 12-42
        //add the second part of the test here
        Assert.Fail("AddAsync_Inserts_New_Item is not fully implemented yet.");
    }

    [Fact]
    public async Task UpdateAsync_Updates_Existing_Item()
    {
        //TODO: Listing 12-43
        Assert.Fail("UpdateAsync_Updates_Existing_Item is not implemented yet.");
    }

    [Fact]
    public async Task UpdateRangeAsync_Updates_Multiple_Items()
    {
        //TODO: Listing 12-44
        Assert.Fail("UpdateRangeAsync_Updates_Multiple_Items is not implemented yet.");
    }

    [Fact]
    public async Task DeleteAsync_Removes_Item()
    {
        //Listing 12-45 - Delete Async
        Assert.Fail("DeleteAsync_Removes_Item is not implemented yet.");
    }
}

