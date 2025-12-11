# Listing 12-29: Test

Use this code to complete the test

## The Code

```cs
// Arrange
var parsedItems = new List<ParsedItemDataDTO>
{
    new ParsedItemDataDTO
    {
        Item = new Item { Name = "Bulk Item", CategoryId = 1 },
        GenreIds = new List<int> { 1 }, // Sci-Fi
        ContributorData = new Dictionary<int, string> { { 1, "Tom Hanks" } } // ContributorId to name or role
    }
};

// Act
var result = await _service.BulkLoadItemDataAsync(parsedItems);

// Assert
result.ShouldBeTrue();
_mockRepository.Verify(r => r.BulkLoadItemDataAsync(parsedItems), Times.Once);

```  