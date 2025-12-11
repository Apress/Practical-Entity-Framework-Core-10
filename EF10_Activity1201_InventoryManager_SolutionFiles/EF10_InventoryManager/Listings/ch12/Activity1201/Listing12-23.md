# Listing 12-23: GetItemByNameWithCategoryAsync_ReturnsItemWithCategory

Use this code to complete the test `GetItemByNameWithCategoryAsync_ReturnsItemWithCategory`

## The Code

```cs
// Act
var result = await _service.GetItemByNameWithCategoryAsync("Inception");

// Assert
result.ShouldNotBeNull();
result.Name.ShouldBe("Inception");
result.Category.ShouldNotBeNull();
result.Category.CategoryName.ShouldBe("Movie");
_mockRepository.Verify(r => r.GetItemByNameWithCategoryAsync("Inception"), Times.Once);
```  