using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

//updated in listing 11-19 to leverage base interface IGenericRepository
public interface IItemRepository : IGenericRepository<Item>
{
    Task<Item?> GetItemByNameWithCategoryAsync(string name);
    Task<Item?> GetItemByNameWithGenreAsync(string name);
    Task<Item?> GetItemByNameWithGenreByNameAsync(string itemName, string genreName);
    Task<List<Item>> GetItemsByFilterAsync(string filter); //THIS Is overkill but was a previous example so kept it
    Task<List<Item>> GetAllItemsWithCategoryAsync();
    Task<int> UpdateRangeAsync(List<Item> items); // Custom method to update range of items
}
