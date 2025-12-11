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

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        return await _categoryRepository.GetByIdAsync(id);
    }
    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be null or empty");
        }
        return await _categoryRepository.GetByNameAsync(name);
    }

    public async Task<Category> AddCategoryAsync(Category Category)
    {
        if (Category == null)
        {
            throw new ArgumentNullException(nameof(Category));
        }
        bool success = await _categoryRepository.AddAsync(Category);
        var categoryResult = await _categoryRepository.GetByNameAsync(Category.CategoryName);
        return categoryResult ?? throw new InvalidOperationException("Category not found after addition.");
    }

    public async Task<Category> UpdateCategoryAsync(Category Category)
    {
        if (Category == null)
        {
            throw new ArgumentNullException(nameof(Category));
        }
        bool success = await _categoryRepository.UpdateAsync(Category);
        if (!success)
        {
            throw new InvalidOperationException("Failed to update the category.");
        }
        var categoryResult = await _categoryRepository.GetByIdAsync(Category.Id);
        return categoryResult ?? throw new InvalidOperationException("Category not found after update.");
    }

    public async Task<Category> DeleteCategoryAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
        }
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new InvalidOperationException("Category not found.");
        }
        var success = await _categoryRepository.DeleteAsync(id);
        if (!success)
        {
            throw new InvalidOperationException("Failed to delete the category.");
        }
        return category;
    }

    public async Task<List<Category>> FindCategoriesAsync(Expression<Func<Category, bool>> predicate)
    {
        return await _categoryRepository.FindAsync(predicate);
    }
}
