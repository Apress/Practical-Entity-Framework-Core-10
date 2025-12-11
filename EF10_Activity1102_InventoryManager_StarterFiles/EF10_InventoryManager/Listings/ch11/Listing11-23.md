# Listing 11-23: The Add Method after refactoring

Refactor add to work as follows:

## The code

Use this code to refactor the `AddItemAsync` method:

```cs
public async Task<Item> AddItemAsync(Item item)
{
    if (item == null)
    {
        throw new ArgumentNullException(nameof(item));
    }
    var success = await _itemRepository.AddAsync(item);
    if (!success)
    {
        throw new InvalidOperationException("Failed to add the item.");
    }
    var itemResult = await _itemRepository.GetByNameAsync(item.Name);
    return itemResult ?? throw new InvalidOperationException("Item not found after addition.");
}
```  
