# Listing 11-21: Updating the GetAllItemsAsync call

Leverage the repository from the service For GetAllAsync() [Generic call to Get all]

## the code
 
```cs
public async Task<List<Item>> GetAllItemsAsync()
{
    return await _itemRepository.GetAllAsync();
}
```  