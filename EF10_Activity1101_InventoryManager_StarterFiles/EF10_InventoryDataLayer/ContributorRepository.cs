using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

public class ContributorRepository : IContributorRepository
{
    private InventoryDbContext _context;

    public ContributorRepository(InventoryDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Contributor>> GetAllContributorsAsync()
    {
        return await Task.FromResult(_context.Contributors.ToList());
    }
    
    public async Task<Contributor?> GetContributorByIdAsync(int id)
    {
        return await _context.Contributors.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Contributor?> GetContributorByNameAsync(string name)
    {
        return await _context.Contributors.SingleOrDefaultAsync(c => c.ContributorName.ToLower() == name.ToLower());
    }

    public async Task<Contributor> AddOrUpdateContributorAsync(Contributor contributor)
    {
        if (contributor == null)
        {
            throw new ArgumentNullException(nameof(contributor));
        }

        if (contributor.Id > 0)
        {
            // Update existing item
            return await Update(contributor);
        }
        return await Add(contributor);
    }

    private async Task<Contributor> Add(Contributor contributor)
    {
        _context.Contributors.Add(contributor);
        await _context.SaveChangesAsync();
        return contributor;
    }

    private async Task<Contributor> Update(Contributor contributor)
    {
        var existingContributor = await _context.Contributors.FindAsync(contributor.Id);
        if (existingContributor == null)
        {
            throw new KeyNotFoundException($"Contributor with ID {contributor.Id} not found.");
        }
        // Update properties
        existingContributor.Description = contributor.Description;
        existingContributor.IsActive = contributor.IsActive;
        existingContributor.ContributorName = contributor.ContributorName;
        await _context.SaveChangesAsync();
        return existingContributor;
    }

    public async Task<Contributor> DeleteContributorAsync(int id)
    {
        var contributor = await _context.Contributors.FindAsync(id);
        if (contributor == null)
        {
            throw new KeyNotFoundException($"Contributor with ID {id} not found.");
        }
        _context.Contributors.Remove(contributor);
        await _context.SaveChangesAsync();
        return contributor;
    }

    public async Task<List<Contributor>> FindContributorAsync(Expression<Func<Contributor, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        return await _context.Contributors.Where(predicate).ToListAsync();
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
