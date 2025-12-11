# Listing 12-22: FindItemsAsync_ReturnsMatchingItems

Use this code to complete the test `FindItemsAsync_ReturnsMatchingItems`

## The Code

```cs
// Arrange
Expression<Func<Item, bool>> predicate = i => i.Name.Contains("The");

// Act
var result = await _service.FindItemsAsync(predicate);

// Assert
result.Count.ShouldBeGreaterThan(0);
_mockRepository.Verify(r => r.FindAsync(predicate), Times.Once);
```  