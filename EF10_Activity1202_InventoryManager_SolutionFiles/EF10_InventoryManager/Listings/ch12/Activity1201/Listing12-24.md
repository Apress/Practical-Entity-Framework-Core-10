# Listing 12-24: GetItemByNameWithGenreAsync_ReturnsItemWithGenres

Use this code to complete the test `GetItemByNameWithGenreAsync_ReturnsItemWithGenres`

## The Code

```cs
// Act
var result = await _service.GetItemByNameWithGenreAsync("Inception");

// Assert
result.ShouldNotBeNull();
result.Name.ShouldBe("Inception");
result.Genres.ShouldNotBeNull();
result.Genres.Count.ShouldBe(2);
_mockRepository.Verify(r => r.GetItemByNameWithGenreAsync("Inception"), Times.Once);
```  