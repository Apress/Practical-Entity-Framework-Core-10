# Listing 12-20: UpdateItemAsync_UpdatesAndReturnsItem

Use this code to complete the test `UpdateItemAsync_UpdatesAndReturnsItem`

## The Code

```cs
// Arrange
var itemToUpdate = new Item { Id = 1, Name = "Updated Item", CategoryId = 1 };

// Act
var result = await _service.UpdateItemAsync(itemToUpdate);

// Assert
result.ShouldNotBeNull();
result.Name.ShouldBe("Updated Item");
_mockRepository.Verify(r => r.UpdateAsync(It.Is<Item>(i => i.Id == 1 && i.Name == "Updated Item")), Times.Once);
```  
