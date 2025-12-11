# Listing 6-28: Remove Item By Id

Takes in the id, finds the match or rejects the operation. When match is found, calls remove to finish the delete operation.

## The code

Use this code to complete the `RemoveItemById` method

```cs
public async Task<bool> RemoveItemById(int itemId)
{
    var item = await _db.Items
        .SingleOrDefaultAsync(i => i.Id == itemId);
    if (item == null)
    {
        Console.WriteLine($"Item with ID '{itemId}' not found.");
        return false; //indicate failure
    }
    return await RemoveItem(item);
}

```  