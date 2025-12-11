# Listing 12-11 : Create Mocks for the Generic methods - Delete

Set up the mock to manipulate the underlying data for delete

## The code

Use the mock to perform an in-memory delete on the underlying list of Items

```cs
_mockRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
{
    var existing = _items.FirstOrDefault(i => i.Id == id);
    if (existing != null)
    {
        _items.Remove(existing);
        return true;
    }
    return false;
});
```  