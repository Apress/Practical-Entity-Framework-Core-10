# Listing 6-12: Update the Create Category Async method - Add a Single Category [Modified]

User can provide input to add a category, including the name and an optional description. 
Replace the

## Implement the Method

The final method to add a category:

```cs
private async Task<Category> CreateCategoryAsync(string categoryName, string? description = null)
{
    var category = await CreateOrGetCategoryAsync(categoryName, description)

    if (category.Id > 0)
    {
        await _db.SaveChangesAsync();
    }
    
    return category;
}
```  