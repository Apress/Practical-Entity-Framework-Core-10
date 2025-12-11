using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;
public interface ICategoryRepository
{
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category?> GetCategoryByNameAsync(string name);
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category> AddOrUpdateCategoryAsync(Category category);
    Task<Category> DeleteCategoryAsync(int id);
    Task<List<Category>> FindCategoriesAsync(Expression<Func<Category, bool>> predicate);
}
