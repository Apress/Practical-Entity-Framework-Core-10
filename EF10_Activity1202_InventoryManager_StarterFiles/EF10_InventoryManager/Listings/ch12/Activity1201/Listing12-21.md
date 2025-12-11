# Listing 12-21: DeleteItemAsync_DeletesAndReturnsItem

Use this code to complete the test `DeleteItemAsync_DeletesAndReturnsItem`

## The Code

```cs
// Act
var result = await _service.DeleteItemAsync(1);

// Assert
result.ShouldNotBeNull();
result.Id.ShouldBe(1);
_mockRepository.Verify(r => r.DeleteAsync(1), Times.Once);
```  