# Listing 11-24: Refactoring Update

Use the code to refactor the Update method in the service layer

## Code

Replace the existing method `UpdateItemAsync` with the following

```cs
public async Task<Item> UpdateItemAsync(Item item)
{
    if (item == null)
    {
        throw new ArgumentNullException(nameof(item));
    }
    var success = await _itemRepository.UpdateAsync(item);
    if (!success)
    {
        throw new InvalidOperationException("Failed to update the item.");
    }
    var itemResult = await _itemRepository.GetByIdAsync(item.Id);
    return itemResult ?? throw new InvalidOperationException("Item not found after Update.");
}
```  