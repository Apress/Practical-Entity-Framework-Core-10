namespace EF10_InventoryManagerUnitTests;

public class TestItemService
{
    //TODO: (Listing 12-1): Define the mocks and service to be used in the tests

    public TestItemService()
    {
        //TODO: (Listing 12-2) Define the mocks and service to be used in the tests
    }

    [Fact]
    public async Task GetAllItemsAsync_ReturnsAllItems()
    {
        //TODO: Test GetAllItemsAsync method (Listing 12-16)
    }

    [Fact]
    public async Task GetItemByIdAsync_ReturnsItemWhenExists()
    {
        //TODO: Test GetItemByIdAsync method when item exists  (Listing 12-17)
    }

    [Fact]
    public async Task GetItemByIdAsync_ReturnsNullWhenNotExists()
    {
        //TODO: Test GetItemByIdAsync method when item does not exist  (Listing 12-18)
    }

    [Fact]
    public async Task AddItemAsync_AddsAndReturnsItem()
    {
        //TODO: Test AddItemAsync method  (Listing 12-19)
    }

    [Fact]
    public async Task UpdateItemAsync_UpdatesAndReturnsItem()
    {
        //TODO: Test UpdateItemAsync method  (Listing 12-20)
    }

    [Fact]
    public async Task DeleteItemAsync_DeletesAndReturnsItem()
    {
        //TODO: Test DeleteItemAsync method (Listing 12-21)
    }

    [Fact]
    public async Task FindItemsAsync_ReturnsMatchingItems()
    {
        //TODO: Test FindItemsAsync method (Listing 12-22)
    }

    [Fact]
    public async Task GetItemByNameWithCategoryAsync_ReturnsItemWithCategory()
    {
        //TODO: Test GetItemByNameWithCategoryAsync method   (Listing 12-23)
    }

    [Fact]
    public async Task GetItemByNameWithGenreAsync_ReturnsItemWithGenres()
    {
        //TODO: Test GetItemByNameWithGenreAsync method (Listing 12-24)
    }

    [Fact]
    public async Task GetItemByNameWithGenreByNameAsync_ReturnsItemIfGenreMatches()
    {
        //TODO: Test GetItemByNameWithGenreByNameAsync method (Listing 12-25)
    }

    [Fact]
    public async Task GetItemsByFilterAsync_ReturnsFilteredItems()
    {
        //TODO: Test GetItemsByFilterAsync method (Listing 12-26)
    }

    [Fact]
    public async Task GetAllItemsWithCategoryAsync_ReturnsItemsWithCategories()
    {
        //TODO: Test GetAllItemsWithCategoryAsync method (Listing 12-27)
    }

    [Fact]
    public async Task UpdateRangeAsync_UpdatesMultipleItems()
    {
        //TODO: Test UpdateRangeAsync method (Listing 12-28)
    }

    [Fact]
    public async Task BulkLoadItemDataAsync_LoadsItems()
    {
        //TODO: Test BulkLoadItemDataAsync method  (Listing 12-29)
    }
}
