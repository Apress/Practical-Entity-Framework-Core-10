# Listing 6-26: Remove an Item by Name

Find the matching item by name and remove it.

## The code

Use this code to complete the `RemoveItemByName` method

```cs
public async Task<bool> RemoveItemByName(string itemName)
{
    if (string.IsNullOrWhiteSpace(itemName))
    {
        throw new ArgumentException("Item name cannot be null or empty.", nameof(itemName));
    }
    var item = await _db.Items
        .SingleOrDefaultAsync(i => i.Name == itemName);
    if (item == null)
    {
        Console.WriteLine($"Item '{itemName}' not found.");
        return false; //indicate failure
    }
    return await RemoveItem(item);
}
```   
