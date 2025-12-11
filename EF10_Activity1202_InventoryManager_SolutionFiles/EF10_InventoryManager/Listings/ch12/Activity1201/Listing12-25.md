# Listing 12-25: GetItemByNameWithGenreByNameAsync_ReturnsItemIfGenreMatches

Use this code to complete the test `GetItemByNameWithGenreByNameAsync_ReturnsItemIfGenreMatches`

## The Code

```cs
// Act
var result = await _service.GetItemByNameWithGenreByNameAsync("Inception", "Sci-Fi");

// Assert
result.ShouldNotBeNull();
result.Name.ShouldBe("Inception");
_mockRepository.Verify(r => r.GetItemByNameWithGenreByNameAsync("Inception", "Sci-Fi"), Times.Once);
```  