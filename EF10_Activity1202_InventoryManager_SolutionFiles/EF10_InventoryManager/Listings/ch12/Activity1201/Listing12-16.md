# Listing 12-16: GetAllItemsAsync_ReturnsAllItems

Use this code to complete the test for `GetAllItemsAsync`

## The Code

```cs
// Act
var result = await _service.GetAllItemsAsync();

// Assert
result.Count.ShouldBe(20);
_mockRepository.Verify(r => r.GetAllAsync(), Times.Once);

//could also test specific items are contained, etc.
```  