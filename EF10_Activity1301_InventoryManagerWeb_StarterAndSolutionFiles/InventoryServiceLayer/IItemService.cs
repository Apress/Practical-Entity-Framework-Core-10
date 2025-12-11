using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;
using System.Linq.Expressions;

namespace EF10_InventoryServiceLayer;

public interface IItemService
{
    Task<List<Item>> GetAllItemsAsync();
    Task<Item?> GetItemByIdAsync(int id);
    Task<Item> AddItemAsync(Item item);
    Task<Item> UpdateItemAsync(Item item);
    Task<Item> DeleteItemAsync(int id);
    Task<List<Item>> FindItemsAsync(Expression<Func<Item, bool>> predicate);

    //custom methods
    Task<Item?> GetItemByNameWithCategoryAsync(string name);
    Task<Item?> GetItemByNameWithGenreAsync(string name);
    Task<Item?> GetItemByNameWithGenreByNameAsync(string itemName, string genreName);

    Task<List<Item>> GetItemsByFilterAsync(string filter); //THIS Is overkill but was a previous example so kept it

    Task<List<Item>> GetAllItemsWithCategoryAsync();

    Task<int> UpdateRangeAsync(List<Item> items);

    Task<bool> BulkLoadItemDataAsync(List<ParsedItemDataDTO> parsedItems);
    Task<List<ItemWithCsvDetailsDTO>> GetFullItemDetails();
    Task<Item?> UpdateItemWithRelationshipsAsync(Item item);
}
