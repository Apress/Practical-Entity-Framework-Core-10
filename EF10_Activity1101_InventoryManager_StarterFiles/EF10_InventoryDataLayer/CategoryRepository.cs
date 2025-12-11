using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

public class CategoryRepository : ICategoryRepository
{
    private readonly InventoryDbContext _context;
    public CategoryRepository(InventoryDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        var category = await _context.Categories.SingleOrDefaultAsync(c => c.CategoryName.ToLower().Equals(name.ToLower()));
        return category;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    public async Task<Category> AddOrUpdateCategoryAsync(Category category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category));
        }
        if (category.Id > 0)
        {
            // Update existing category
            return await Update(category);
        }
        return await Add(category);
    }

    private async Task<Category> Add(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    private async Task<Category> Update(Category category)
    {
        var existingCategory = await _context.Categories.FindAsync(category.Id);
        if (existingCategory == null)
        {
            throw new KeyNotFoundException($"Category with ID {category.Id} not found");
        }
        // Update properties
        existingCategory.CategoryName = category.CategoryName;
        existingCategory.Description = category.Description;
        existingCategory.IsActive = category.IsActive;
        _context.Categories.Update(existingCategory);

        await _context.SaveChangesAsync();
        return existingCategory;
    }

    public async Task<Category> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            throw new KeyNotFoundException($"Category with ID {id} not found.");
        }
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<List<Category>> FindCategoriesAsync(Expression<Func<Category, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        return await _context.Categories.Where(predicate).ToListAsync();
    }



    
}
