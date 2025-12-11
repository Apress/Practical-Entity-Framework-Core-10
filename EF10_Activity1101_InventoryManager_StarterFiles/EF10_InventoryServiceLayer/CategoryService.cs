using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryServiceLayer;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepo)
    {
        _categoryRepository = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllCategoriesAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        return await _categoryRepository.GetCategoryByIdAsync(id);
    }
    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be null or empty");
        }
        return await _categoryRepository.GetCategoryByNameAsync(name);
    }

    public async Task<Category> AddCategoryAsync(Category Category)
    {
        if (Category == null)
        {
            throw new ArgumentNullException(nameof(Category));
        }
        return await _categoryRepository.AddOrUpdateCategoryAsync(Category);
    }

    public async Task<Category> UpdateCategoryAsync(Category Category)
    {
        if (Category == null)
        {
            throw new ArgumentNullException(nameof(Category));
        }
        return await _categoryRepository.AddOrUpdateCategoryAsync(Category);
    }

    public async Task<Category> DeleteCategoryAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        return await _categoryRepository.DeleteCategoryAsync(id);
    }

    public async Task<IEnumerable<Category>> FindCategoriesAsync(Expression<Func<Category, bool>> predicate)
    {
        return await _categoryRepository.FindCategoriesAsync(predicate);
    }
}
