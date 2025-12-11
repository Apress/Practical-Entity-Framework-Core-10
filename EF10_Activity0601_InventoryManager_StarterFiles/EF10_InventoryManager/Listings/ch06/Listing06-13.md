# Listing 6-13: Create or get an item asynchronously

Find the item by name, and return it if it exists, or create a new item in memory.  No changes are persisted to the database.

## Implement the Method

The code below already exists in the starter files, so you shouldn't need to add it, but you can take a minute to review the functionality.


```cs
public async Task<Item> CreateOrGetItemAsync(string itemName, string itemDescription)
{
    // Check if the item already exists (hydrate category)
    var existingItem = await _db.Items
                                .Include(i => i.Category)
        .Where(x => x.Name.ToLower() == itemName.ToLower())
        .SingleOrDefaultAsync();
    if (existingItem != null)
    {
        Console.WriteLine($"Item '{existingItem.Name}' already exists with ID: {existingItem.Id}");
        return existingItem; // Return the existing item
    }
    // Create a new item if it doesn't exist
    var newItem = new Item
    {
        Name = itemName,
        Description = itemDescription,
    };
    return newItem;
}
```  
