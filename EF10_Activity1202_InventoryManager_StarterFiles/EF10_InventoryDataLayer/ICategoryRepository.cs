using EF10_InventoryModels;

namespace EF10_InventoryDataLayer;
public interface ICategoryRepository : IGenericRepository<Category>
{
    //There are no custom methods for Category, so this interface is empty.
}
