# Listing 12-17: GetItemByIdAsync_ReturnsItemWhenExists

Use this code to complete the test `GetItemByIdAsync_ReturnsItemWhenExists`

## The Code

```cs
// Act
var result = await _service.GetItemByIdAsync(1);

// Assert
result.ShouldNotBeNull();
result.Id.ShouldBe(1);
result.Name.ShouldBe("Inception");
_mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
```  