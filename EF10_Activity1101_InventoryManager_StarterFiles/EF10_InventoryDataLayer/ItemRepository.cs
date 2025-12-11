using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

public class ItemRepository : IItemRepository
{
    private readonly InventoryDbContext _context;

    public ItemRepository(InventoryDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Item>> GetAllItemsAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<List<Item>> GetAllItemsWithCategoryAsync()
    {
        return await _context.Items.Include(x => x.Category).ToListAsync();
    }

    public async Task<Item?> GetItemByIdAsync(int id)
    {
        var item = await _context.Items.SingleOrDefaultAsync(i => i.Id == id);
        return item ?? throw new KeyNotFoundException($"Item with ID {id} not found.");
    }

    public async Task<Item> AddOrUpdateItemAsync(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        
        if (item.Id > 0)
        {
            // Update existing item
            return await Update(item);
        }
        return await Add(item);
    }

    private async Task<Item> Add(Item item)
    {
        
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    private async Task<Item> Update(Item item)
    {
        var existingItem = await _context.Items.FindAsync(item.Id);
        if (existingItem == null)
        {
            throw new KeyNotFoundException($"Item with ID {item.Id} not found.");
        }
        // Update properties
        existingItem.Name = item.Name;
        existingItem.Quantity = item.Quantity;
        existingItem.Description = item.Description;
        existingItem.Notes = item.Notes;
        existingItem.IsOnSale = item.IsOnSale;
        existingItem.PurchasedDate = item.PurchasedDate;
        existingItem.SoldDate = item.SoldDate;
        existingItem.PurchasePrice = item.PurchasePrice;
        existingItem.CurrentValue = item.CurrentValue;
        existingItem.CategoryId = item.CategoryId;
        await _context.SaveChangesAsync();
        return existingItem;
    }

    public async Task<Item> DeleteItemAsync(int id)
    {
        var item = _context.Items.Find(id);
        if (item == null)
        {
            throw new KeyNotFoundException($"Item with ID {id} not found.");
        }
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<List<Item>> FindItemAsync(Expression<Func<Item, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        return await _context.Items.Where(predicate).ToListAsync();
    }

    public async Task<Item?> GetItemByNameWithCategoryAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
        }
        return await _context.Items
            .Include(i => i.Category)
            .Where(x => x.Name != null && x.Name.ToLower() == name.ToLower())
            .SingleOrDefaultAsync();
    }

    public async Task<Item?> GetItemByNameWithGenreAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
        }
        return await _context.Items
            .Include(i => i.Genres)
            .Where(x => x.Name != null && x.Name.ToLower() == name.ToLower())
            .SingleOrDefaultAsync();
    }

    public async Task<Item?> GetItemByNameWithGenreByNameAsync(string itemName, string genreName)
    {
        if (string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(genreName))
        {
            throw new ArgumentNullException("Item name and genre name cannot be null or empty.");
        }
        return await _context.Items
            .Include(i => i.Genres)
            .Where(x => x.Name != null && x.Name.ToLower() == itemName.ToLower()
                        && x.Genres.Any(g => g.GenreName.ToLower() == genreName.ToLower()))
            .SingleOrDefaultAsync();
    }   


    public async Task<List<Item>> GetItemsByFilterAsync(string filter)
    {
        return await _context.Items
                        .Where(x => string.IsNullOrWhiteSpace(filter)
                                    || x.Name.Contains(filter))
                        .OrderBy(x => x.Name)
                        .ToListAsync();
    }

    public async Task<int> UpdateRangeAsync(List<Item> items)
    {
        if (items == null || !items.Any())
        {
            throw new ArgumentNullException(nameof(items), "Items list cannot be null or empty.");
        }
        _context.Items.UpdateRange(items);
        return await _context.SaveChangesAsync();
    }
}
