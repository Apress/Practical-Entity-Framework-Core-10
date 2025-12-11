# Listing 6-14: Create an Item and Category at the same time

Create a new Item, then associate to a new Category. The reason you are doing this is to see that relational data will be created effectively without having to make separate calls to save data to each table or worry about the order of operations.

## Implement the Method

Use the code below to create an Item and a Category that is associated in one operation.

```cs
private async Task<Item> CreateItemAndCategoryAsync(string itemName, string itemDescription
        , string categoryName, string? categoryDescription = null)
{
    // Create or get the category (not saving to the database yet)
    var category = await CreateOrGetCategoryAsync(categoryName, categoryDescription);
    // Create or get the item (not saving to the database yet)
    var item = await CreateOrGetItemAsync(itemName, itemDescription);
    if (item.Id > 0)
    {
        Console.WriteLine($"Item '{item.Name}' already exists with ID: {item.Id}");
        return item; // Return the existing item
    }
    // Associate the item with the category (note, not using the CategoryId property here)
    item.Category = category;
    // Add the item to the context, this will track the item in memory
    _db.Items.Add(item);
    // Save changes to the database
    await _db.SaveChangesAsync();
    return item;
}
```  