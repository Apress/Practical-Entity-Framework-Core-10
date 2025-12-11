# Listing 12-8 : Create Mocks for the Generic methods - AddAsync

Set up the mock to manipulate the underlying data for `Add`

## The code

Use the mock to perform an in-memory `Add` on the underlying list of Items

```cs
_mockRepository.Setup(r => r.AddAsync(It.IsAny<Item>())).ReturnsAsync((Item entity) =>
{
    entity.Id = _items.Max(i => i.Id) + 1;
    _items.Add(entity);
    return true;
});
```  