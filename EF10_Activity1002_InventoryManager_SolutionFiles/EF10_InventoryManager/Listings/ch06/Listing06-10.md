# Listing 6-10: Add a Single Category

User can provide input to add a category, including the name and an optional description. 

## Implement the Method

The final method to add a category:

```cs
private async Task<Category> CreateCategoryAsync(string categoryName, string? description = null)
{
    if (string.IsNullOrWhiteSpace(categoryName))
    {
        throw new ArgumentException("Category name cannot be null or empty.", nameof(categoryName));
    }
    // Check if the category already exists
    var existingCategory = await _db.Categories
            .SingleOrDefaultAsync(c => c.CategoryName.ToLower() == categoryName.ToLower());
    if (existingCategory != null)
    {
        // return the existing category if it already exists
        Console.WriteLine($"Category '{categoryName}' already exists with ID: {existingCategory.Id}");
        return existingCategory;
    }
    // Create a new category if it does not exist
    var category = new Category { CategoryName = categoryName, Description = description };
    _db.Categories.Add(category);
    await _db.SaveChangesAsync();
    return category;
}
```  