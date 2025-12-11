# Listing 12-13 : Create Mocks for the Custom repository methods - All Get operations

Set up the mock to manipulate the underlying data for all the custom `Get` operations

## The code

The custom repository has a number of `Get` operations.  Use this code to handle them:

```cs
_mockRepository.Setup(r => r.GetItemByNameWithCategoryAsync(It.IsAny<string>())).ReturnsAsync((string name) => _items.FirstOrDefault(i => i.Name == name));
_mockRepository.Setup(r => r.GetItemByNameWithGenreAsync(It.IsAny<string>())).ReturnsAsync((string name) => _items.FirstOrDefault(i => i.Name == name));
_mockRepository.Setup(r => r.GetItemByNameWithGenreByNameAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((string itemName, string genreName) => _items.FirstOrDefault(i => i.Name == itemName && i.Genres != null && i.Genres.Any(g => g.GenreName == genreName)));
_mockRepository.Setup(r => r.GetItemsByFilterAsync(It.IsAny<string>())).ReturnsAsync((string filter) => _items.Where(i => i.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList());
_mockRepository.Setup(r => r.GetAllItemsWithCategoryAsync()).ReturnsAsync(_items.ToList());
```  

### Methods

- GetItemByNameWithCategoryAsync
- GetItemByNameWithGenreAsync
- GetItemByNameWithGenreByNameAsync
- GetItemsByFilterAsync
- GetAllItemsWithCategoryAsync