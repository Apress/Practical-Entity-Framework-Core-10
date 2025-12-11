using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;
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
        //Listing 11-21
        return await _itemRepository.GetAllAsync();
    }

    public async Task<List<Item>> GetAllItemsWithCategoryAsync()
    {
        return await _itemRepository.GetAllItemsWithCategoryAsync();
    }

    public async Task<Item?> GetItemByIdAsync(int id)
    {
        //Listing 11-22
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        return await _itemRepository.GetByIdAsync(id);

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
        //Listing 11-23
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        var success = await _itemRepository.AddAsync(item);
        if (!success)
        {
            throw new InvalidOperationException("Failed to add the item.");
        }
        var itemResult = await _itemRepository.GetByNameAsync(item.Name);
        return itemResult ?? throw new InvalidOperationException("Item not found after addition.");
    }


    public async Task<Item> UpdateItemAsync(Item item)
    {
        //Listing 11-24
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        var success = await _itemRepository.UpdateAsync(item);
        if (!success)
        {
            throw new InvalidOperationException("Failed to update the item.");
        }
        var itemResult = await _itemRepository.GetByIdAsync(item.Id);
        return itemResult ?? throw new InvalidOperationException("Item not found after Update.");
    }

    public async Task<Item> DeleteItemAsync(int id)
    {
        //Listing 11-25
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        var item = await _itemRepository.GetByIdAsync(id);
        bool success = await _itemRepository.DeleteAsync(id);
        if (!success)
        {
            throw new InvalidOperationException("Failed to delete the item.");
        }
        return item;
    }

    public async Task<List<Item>> FindItemsAsync(Expression<Func<Item, bool>> predicate)
    {
        //Listing 11-26
        return await _itemRepository.FindAsync(predicate);
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

    //1102
    public async Task<bool> BulkLoadItemDataAsync(List<ParsedItemDataDTO> parsedItems)
    {
        if (parsedItems == null || !parsedItems.Any())
        {
            throw new ArgumentNullException(nameof(parsedItems), "Parsed items list cannot be null or empty.");
        }

        return await _itemRepository.BulkLoadItemDataAsync(parsedItems);
    }
}
