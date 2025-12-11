using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryServiceLayer;

public interface ICategoryService
{
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task<Category> DeleteCategoryAsync(int id);
    Task<List<Category>> GetAllCategoriesAsync();
    Task<List<Category>> FindCategoriesAsync(Expression<Func<Category, bool>> predicate);

    //custom methods
    Task<Category?> GetCategoryByNameAsync(string name);
}
