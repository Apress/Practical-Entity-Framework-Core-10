# Listing 12-10 : Create Mocks for the Generic methods - Update

Set up the mock to manipulate the underlying data for update

## The code

Use the mock to perform an in-memory update on the underlying list of Items

```cs
_mockRepository.Setup(r => r.UpdateAsync(It.IsAny<Item>())).ReturnsAsync((Item entity) =>
{
    var existing = _items.FirstOrDefault(i => i.Id == entity.Id);
    if (existing != null)
    {
        _items.Remove(existing);
        _items.Add(entity);
        return true;
    }
    return false;
});
```  