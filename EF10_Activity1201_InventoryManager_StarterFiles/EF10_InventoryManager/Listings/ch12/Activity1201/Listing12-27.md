# Listing 12-27: GetAllItemsWithCategoryAsync_ReturnsItemsWithCategories

Use this code to complete the test `GetAllItemsWithCategoryAsync_ReturnsItemsWithCategories`

## The Code

```cs
// Act
var result = await _service.GetAllItemsWithCategoryAsync();

// Assert
result.Count.ShouldBe(20);
result.ShouldAllBe(i => i.Category != null);
_mockRepository.Verify(r => r.GetAllItemsWithCategoryAsync(), Times.Once);
```  