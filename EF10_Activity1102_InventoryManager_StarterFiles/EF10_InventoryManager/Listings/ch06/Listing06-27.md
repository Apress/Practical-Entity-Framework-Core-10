# Listing 6-27: Remove a tracked item

Takes in the tracked item and removes it - a helper method for common logic to remove.

## The code

Use this code to complete the `RemoveItem` method

```cs
private async Task<bool> RemoveItem(Item item)
{
    _db.Items.Remove(item);
    var result = await _db.SaveChangesAsync();
    return result == 1; //return true if one row was deleted
}
```  