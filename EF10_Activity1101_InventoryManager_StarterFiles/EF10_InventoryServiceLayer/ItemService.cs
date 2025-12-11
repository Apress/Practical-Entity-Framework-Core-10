using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryServiceLayer;

public class ItemService : IItemService
{
    private IItemRepository _itemRepository;
    public ItemService(IItemRepository itemRepo)
    {
       _itemRepository = itemRepo ?? throw new ArgumentNullException(nameof(itemRepo));
    }

    public async Task<List<Item>> GetAllItemsAsync()
    {
        return await _itemRepository.GetAllItemsAsync();
    }

    public async Task<List<Item>> GetAllItemsWithCategoryAsync()
    {
        return await _itemRepository.GetAllItemsWithCategoryAsync();
    }

    public async Task<Item?> GetItemByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        return await _itemRepository.GetItemByIdAsync(id);
    }

    public async Task<Item?> GetItemByNameWithCategoryAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "name must not be empty");
        }
        return await _itemRepository.GetItemByNameWithCategoryAsync(name);
    }

    public async Task<Item?> GetItemByNameWithGenreAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "name must not be empty");
        }
        return await _itemRepository.GetItemByNameWithGenreAsync(name);
    }

    public async Task<Item?> GetItemByNameWithGenreByNameAsync(string itemName, string genreName)
    { 
        if (string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(genreName))
        {
            throw new ArgumentOutOfRangeException("Both itemName and genreName must not be empty.");
        }
        return await _itemRepository.GetItemByNameWithGenreByNameAsync(itemName, genreName);
    }

    public async Task<Item> AddItemAsync(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        return await _itemRepository.AddOrUpdateItemAsync(item);
    }

    public async Task<Item> UpdateItemAsync(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        return await _itemRepository.AddOrUpdateItemAsync(item);
    }

    public async Task<Item> DeleteItemAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        return await _itemRepository.DeleteItemAsync(id);
    }

    public async Task<List<Item>> FindItemsAsync(Expression<Func<Item, bool>> predicate)
    {
        return await _itemRepository.FindItemAsync(predicate);
    }

    public async Task<List<Item>> GetItemsByFilterAsync(string filter)
    { 
        return await _itemRepository.GetItemsByFilterAsync(filter);
    }

    public async Task<int> UpdateRangeAsync(List<Item> items)
    { 
        if (items == null || !items.Any())
        {
            throw new ArgumentNullException(nameof(items), "Items list cannot be null or empty.");
        }
        return await _itemRepository.UpdateRangeAsync(items);
    }
}
