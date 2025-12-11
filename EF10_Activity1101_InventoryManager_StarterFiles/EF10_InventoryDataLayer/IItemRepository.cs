using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

public interface IItemRepository
{
    Task<Item?> GetItemByIdAsync(int id);
    Task<Item?> GetItemByNameWithCategoryAsync(string name);
    Task<Item?> GetItemByNameWithGenreAsync(string name);
    Task<Item?> GetItemByNameWithGenreByNameAsync(string itemName, string genreName);
    Task<List<Item>> GetAllItemsAsync();
    Task<Item> AddOrUpdateItemAsync(Item item);
    Task<Item> DeleteItemAsync(int id);
    Task<List<Item>> FindItemAsync(Expression<Func<Item, bool>> predicate);

    //custom
    Task<List<Item>> GetItemsByFilterAsync(string filter); //THIS Is overkill but was a previous example so kept it

    Task<List<Item>> GetAllItemsWithCategoryAsync();

    Task<int> UpdateRangeAsync(List<Item> items); // Custom method to update range of items

}
