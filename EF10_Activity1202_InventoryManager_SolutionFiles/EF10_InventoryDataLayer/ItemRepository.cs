using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;
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

    public async Task<bool> BulkLoadItemDataAsync(List<ParsedItemDataDTO> parsedItems)
    {
        var itemContributorsToAdd = new List<ItemContributor>();
        var genreStubs = new Dictionary<int, Genre>();

        //stub in genres first to avoid tracking conflicts
        //Only doing this to cause invalid genre ids to make it to the transaction
        //if you used a list of genres, you would just attach the existing genre and you'd be good
        //or even add if it doesn't exist (but you'd need genre information).
        foreach (var parsed in parsedItems)
        {
            foreach (var genreId in parsed.GenreIds)
            {
                if (!genreStubs.TryGetValue(genreId, out var genreStub))
                {
                    genreStub = _context.Genres.Local.FirstOrDefault(g => g.Id == genreId);
                    if (genreStub == null)
                    {
                        genreStub = new Genre { Id = genreId };
                        _context.Attach(genreStub);
                    }
                    genreStubs[genreId] = genreStub;
                }
                parsed.Item.Genres.Add(genreStub);
            }
        }

        // Now, wrap in transaction
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                // Add and save items first to generate IDs and insert m2m joins
                _context.Items.AddRange(parsedItems.Select(p => p.Item));
                _context.SaveChanges();

                // Now build and add ItemContributors with generated ItemIds
                foreach (var parsed in parsedItems)
                {
                    foreach (var kvp in parsed.ContributorData)
                    {
                        itemContributorsToAdd.Add(new ItemContributor
                        {
                            ItemId = parsed.Item.Id, // Now set after save
                            ContributorId = kvp.Key,
                            ContributorType = Enum.Parse<ContributorType>(kvp.Value, true)
                        });
                    }
                }
                _context.ItemContributors.AddRange(itemContributorsToAdd);
                _context.SaveChanges();

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw; // Or handle as needed
            }
            finally
            {
                // Detach genre stubs to avoid tracking conflicts in subsequent calls
                foreach (var stub in genreStubs.Values)
                {
                    _context.Entry(stub).State = EntityState.Detached;
                }
            }
        }
    }
}
