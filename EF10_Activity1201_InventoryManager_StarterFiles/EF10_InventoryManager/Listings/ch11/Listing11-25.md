# Listing 11-25: The Delete method rewritten

Delete should probably be refactored to the UI to avoid extra overhead

## the code

Use the following code to update the DeleteItemAsync method to leverage the repository

```cs
public async Task<Item> DeleteItemAsync(int id)
{
    if (id <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
    }
    var item = await _itemRepository.GetByIdAsync(id);
    bool success = await _itemRepository.DeleteAsync(id);
    if (!success)
    {
        throw new InvalidOperationException("Failed to delete the item.");
    }
    return item;
}
```  