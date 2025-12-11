# Listing 12-7: Create Mocks for the Generic methods - GetByIdAsync 

Set up the mock to return the specific Item when an `Id` int is passed

## The code

As a reminder, what is returned here is not as relevant as the shape. When any integer is passed, the call should return one, and only one, item.

The mock ensures that an int is passed, then gets the item from the list based on the passed in `Id`.

If you realy didn't care, you could just return `_items.First()`or `_items[0]`, no matter what `id` was passed in.

Mock `r.GetByIdAsync` with the following code:

```cs
_mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => _items.FirstOrDefault(i => i.Id == id));
```  
