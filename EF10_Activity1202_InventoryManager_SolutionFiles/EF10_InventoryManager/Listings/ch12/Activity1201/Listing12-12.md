# Listing 12-12 : Create Mocks for the Generic methods - Find

Set up the mock to manipulate the underlying data for `Find`

## The code

Use the mock to perform an in-memory `Find` on the underlying list of Items

```cs
_mockRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Item, bool>>>())).ReturnsAsync((Expression<Func<Item, bool>> predicate) => _items.Where(predicate.Compile()).ToList());
```  
