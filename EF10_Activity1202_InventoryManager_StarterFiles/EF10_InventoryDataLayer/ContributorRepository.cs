using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryDataLayer;

public class ContributorRepository : GenericRepository<Contributor>, IContributorRepository
{
    private InventoryDbContext _context;

    public ContributorRepository(InventoryDbContext context)
        : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<int> AddRangeAsync(List<Contributor> contributors)
    {
        if (contributors == null || !contributors.Any())
        {
            throw new ArgumentNullException(nameof(contributors), "Contributors list cannot be null or empty.");
        }
        await _context.Contributors.AddRangeAsync(contributors);
        return await _context.SaveChangesAsync();
    }

    public async Task<Contributor?> GetContributorByNameWithItemsAsync(string name)
    {
        return await _context.Contributors
                                    .Include(x => x.ItemContributors)
                                    .ThenInclude(y => y.Item)
                                    .Where(x => x.ContributorName.ToLower() == name.ToLower())
                                    .SingleOrDefaultAsync();
    }
}
