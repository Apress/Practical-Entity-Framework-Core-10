using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

public interface IContributorRepository
{
    Task<Contributor?> GetContributorByIdAsync(int id);
    Task<Contributor?> GetContributorByNameAsync(string name);
    Task<List<Contributor>> GetAllContributorsAsync();
    Task<Contributor> AddOrUpdateContributorAsync(Contributor Contributor);
    Task<Contributor> DeleteContributorAsync(int id);
    Task<List<Contributor>> FindContributorAsync(Expression<Func<Contributor, bool>> predicate);

    Task<int> AddRangeAsync(List<Contributor> contributors); // Custom method to add range of contributors

    Task<Contributor?> GetContributorByNameWithItemsAsync(string name);
}
