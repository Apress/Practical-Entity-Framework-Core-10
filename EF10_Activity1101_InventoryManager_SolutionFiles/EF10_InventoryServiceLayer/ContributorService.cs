using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using System.Linq.Expressions;
namespace EF10_InventoryServiceLayer;
public class ContributorService : IContributorService
{
    private IContributorRepository _contributorRepository;
    public ContributorService(IContributorRepository contributorRepo)
    {
        _contributorRepository = contributorRepo ?? throw new ArgumentNullException(nameof(contributorRepo));
    }

    public async Task<IEnumerable<Contributor>> GetAllContributorsAsync()
    {
        return await _contributorRepository.GetAllAsync();
    }

    public async Task<Contributor?> GetContributorByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        return await _contributorRepository.GetByIdAsync(id);
    }

    public async Task<Contributor?> GetContributorByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be null or empty");
        }
        return await _contributorRepository.GetByNameAsync(name);
    }

    public async Task<Contributor> AddContributorAsync(Contributor contributor)
    {
        if (contributor == null)
        {
            throw new ArgumentNullException(nameof(contributor));
        }
        var success = await _contributorRepository.AddAsync(contributor);
        if (!success)
        {
            throw new InvalidOperationException("Failed to add the contributor.");
        }
        var contributorResult = await _contributorRepository.GetByNameAsync(contributor.ContributorName);
        return contributorResult ?? throw new InvalidOperationException("Contributor not found after addition.");
    }

    public async Task<Contributor> UpdateContributorAsync(Contributor contributor)
    {
        if (contributor == null)
        {
            throw new ArgumentNullException(nameof(contributor));
        }
        var success = await _contributorRepository.UpdateAsync(contributor);
        if (!success)
        {
            throw new InvalidOperationException("Failed to update the contributor.");
        }
        var contributorResult = await _contributorRepository.GetByIdAsync(contributor.Id);
        return contributorResult ?? throw new InvalidOperationException("Contributor not found after update.");
    }

    public async Task<Contributor> DeleteContributorAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        var contributor = await _contributorRepository.GetByIdAsync(id);
        if (contributor == null)
        {
            throw new KeyNotFoundException($"Contributor with ID {id} not found.");
        }
        var success = await _contributorRepository.DeleteAsync(id);
        if (!success)
        {
            throw new InvalidOperationException("Failed to delete the contributor.");
        }
        return contributor;
    }
    public async Task<IEnumerable<Contributor>> FindContributorsAsync(Expression<Func<Contributor, bool>> predicate)
    {
        return await _contributorRepository.FindAsync(predicate);
    }

    public async Task<int> AddRangeAsync(List<Contributor> contributors)
    {
        if (contributors == null || contributors.Count == 0)
        {
            throw new ArgumentNullException(nameof(contributors), "Contributors list cannot be null or empty.");
        }
        return await _contributorRepository.AddRangeAsync(contributors);
    }

    public async Task<Contributor?> GetContributorByNameWithItemsAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "name must not be empty");
        }
        return await _contributorRepository.GetContributorByNameWithItemsAsync(name);
    }
}
