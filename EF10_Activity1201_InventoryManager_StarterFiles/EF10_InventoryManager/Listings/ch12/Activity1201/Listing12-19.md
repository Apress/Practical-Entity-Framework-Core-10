# Listing 12-19: AddItemAsync_AddsAndReturnsItem

Use this code to complete the test `AddItemAsync_AddsAndReturnsItem`

## The Code

```cs
// Arrange
var newItem = new Item { Name = "New Item", CategoryId = 1 };

// Act
var result = await _service.AddItemAsync(newItem);

// Assert
result.ShouldNotBeNull();
result.Name.ShouldBe("New Item");
result.Id.ShouldBeGreaterThan(0);
_mockRepository.Verify(r => r.AddAsync(It.Is<Item>(i => i.Name == "New Item")), Times.Once);
```  