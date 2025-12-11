# Listing 11-26: The find method rewritten

Use the Repository in the `FindItemsAsync` method.

## The code

Leverage the code below to complete the FindItemsAsync method

```cs
public async Task<List<Item>> FindItemsAsync(Expression<Func<Item, bool>> predicate)
{
    return await _itemRepository.FindAsync(predicate);
}
```  