using EF10_InventoryModels;

namespace EF10_InventoryDataLayer;

public interface IContributorRepository : IGenericRepository<Contributor>
{
    Task<int> AddRangeAsync(List<Contributor> contributors); // Custom method to add range of contributors

    Task<Contributor?> GetContributorByNameWithItemsAsync(string name);
}
