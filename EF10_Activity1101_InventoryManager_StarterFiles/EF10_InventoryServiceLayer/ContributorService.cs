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
        return await _contributorRepository.GetAllContributorsAsync();
    }

    

    public async Task<Contributor?> GetContributorByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        return await _contributorRepository.GetContributorByIdAsync(id);
    }

    public async Task<Contributor?> GetContributorByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be null or empty");
        }
        return await _contributorRepository.GetContributorByNameAsync(name);
    }

    public async Task<Contributor> AddContributorAsync(Contributor contributor)
    {
        if (contributor == null)
        {
            throw new ArgumentNullException(nameof(contributor));
        }
        return await _contributorRepository.AddOrUpdateContributorAsync(contributor);
    }

    public async Task<Contributor> UpdateContributorAsync(Contributor contributor)
    {
        if (contributor == null)
        {
            throw new ArgumentNullException(nameof(contributor));
        }
        return await _contributorRepository.AddOrUpdateContributorAsync(contributor);
    }

    public async Task<Contributor> DeleteContributorAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        return await _contributorRepository.DeleteContributorAsync(id);
    }
    public async Task<IEnumerable<Contributor>> FindContributorsAsync(Expression<Func<Contributor, bool>> predicate)
    {
        return await _contributorRepository.FindContributorAsync(predicate);
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
