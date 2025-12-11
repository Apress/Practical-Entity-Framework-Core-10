using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryServiceLayer;

public interface IContributorService
{
    Task<Contributor?> GetContributorByIdAsync(int id);
    Task<Contributor?> GetContributorByNameAsync(string name);
    Task<Contributor> AddContributorAsync(Contributor Contributor);
    Task<Contributor> UpdateContributorAsync(Contributor Contributor);
    Task<Contributor> DeleteContributorAsync(int id);
    Task<IEnumerable<Contributor>> GetAllContributorsAsync();
    Task<IEnumerable<Contributor>> FindContributorsAsync(Expression<Func<Contributor, bool>> predicate);

    Task<int> AddRangeAsync(List<Contributor> contributors); // Custom method to add range of contributors

    Task<Contributor?> GetContributorByNameWithItemsAsync(string name);
}
