# Listing 12-26: GetItemsByFilterAsync_ReturnsFilteredItems

Use this code to complete the test `GetItemsByFilterAsync_ReturnsFilteredItems`

## The Code

```cs
// Act
var result = await _service.GetItemsByFilterAsync("The");

// Assert
result.Count.ShouldBeGreaterThan(0);
_mockRepository.Verify(r => r.GetItemsByFilterAsync("The"), Times.Once);
```  