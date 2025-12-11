# Listing 12-18: GetItemByIdAsync_ReturnsNullWhenNotExists

Use this code to complete the test `GetItemByIdAsync_ReturnsNullWhenNotExists`

## The Code

```cs
// Act
var result = await _service.GetItemByIdAsync(999);

// Assert
result.ShouldBeNull();
_mockRepository.Verify(r => r.GetByIdAsync(999), Times.Once);
```  
