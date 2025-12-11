# Listing 11-22: Get Item By Id Async

Change the service to Get Item by Id from the repository

## The code

Update `GetItemByIdAsync` to:

```cs
public async Task<Item?> GetItemByIdAsync(int id)
{
    if (id <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
    }
    return await _itemRepository.GetByIdAsync(id);
}
```  
