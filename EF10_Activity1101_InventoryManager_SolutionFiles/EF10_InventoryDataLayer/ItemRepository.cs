using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    private readonly InventoryDbContext _context;

    public ItemRepository(InventoryDbContext context)
        : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Item>> GetAllItemsWithCategoryAsync()
    {
        return await _context.Items.Include(x => x.Category).ToListAsync();
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
