# Listing 12-8 : Create Mocks for the Generic methods - GetByNameAsync 

Set up the mock to return the specific `Item` when any string `name` is passed in

## The code

Use the mock to get a valid item by `Name`

```cs
_mockRepository.Setup(r => r.GetByNameAsync(It.IsAny<string>())).ReturnsAsync((string name) => _items.FirstOrDefault(i => i.Name == name));
```  