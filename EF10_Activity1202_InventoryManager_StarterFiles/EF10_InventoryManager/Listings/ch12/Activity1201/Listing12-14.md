# Listing 12-14 : Create Mocks for the Custom repository methods - UpdateRangeAsync

Set up the mock to manipulate the underlying data for all the custom Get operations

## The code

The custom repository has a number of Get operations.  Use this code to handle them:

```cs
_mockRepository.Setup(r => r.UpdateRangeAsync(It.IsAny<List<Item>>())).ReturnsAsync((List<Item> itemsToUpdate) =>
{
    int updatedCount = 0;
    foreach (var updatedItem in itemsToUpdate)
    {
        var existing = _items.FirstOrDefault(i => i.Id == updatedItem.Id);
        if (existing != null)
        {
            _items.Remove(existing);
            _items.Add(updatedItem);
            updatedCount++;
        }
    }
    return updatedCount;
});
```  