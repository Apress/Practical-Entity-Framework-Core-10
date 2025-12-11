# Listing 6-11: Add a Single Category to the in-memory context tracking

Get input from the user - if the category already exists, use the existing category.  If the category does not exist, create one in memory but do not save to the database.

## Review the Method

This method already exists in the code from the starter files, under the CreateCategoryAsync method you implemented in the last step.

```cs
private async Task<Category> CreateCategoryAsync(string categoryName, string? description = null)
{
    if (string.IsNullOrWhiteSpace(categoryName))
    {
        throw new ArgumentException("Category name cannot be null or empty.", nameof(categoryName));
    }
    // Check if the category already exists
    var existingCategory = await _db.Categories
            .SingleOrDefaultAsync(c => c.CategoryName.ToLower == categoryName.ToLower());
    if (existingCategory != null)
    {
        // return the existing category if it already exists
        Console.WriteLine($"Category '{categoryName}' already exists with ID: {existingCategory.Id}");
        return existingCategory;
    }
    // Create a new category if it does not exist
    var category = new Category { CategoryName = categoryName, Description = description };
    _db.Categories.Add(category);
    return category;
}
```  