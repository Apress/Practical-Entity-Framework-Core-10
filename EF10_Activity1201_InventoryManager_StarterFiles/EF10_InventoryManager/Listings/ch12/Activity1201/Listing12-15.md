# Listing 12-14 : Create Mocks for the Custom repository methods - BulkLoadItemDataAsync

Make sure can still do the `BulkLoadAsync`

## The code

Use this mock setup to make sure the `BulkLoadAsync` is configured to operate as expected.

```cs
_mockRepository.Setup(r => r.BulkLoadItemDataAsync(It.IsAny<List<ParsedItemDataDTO>>())).ReturnsAsync((List<ParsedItemDataDTO> parsedItems) =>
{
    foreach (var dto in parsedItems)
    {
        dto.Item.Id = _items.Max(i => i.Id) + 1;
        dto.Item.CategoryId = _categories.FirstOrDefault(c => c.Items.Any(i => i.Id == dto.Item.Id))?.Id ?? dto.Item.CategoryId;
        dto.Item.Genres = _genres.Where(g => dto.GenreIds.Contains(g.Id)).ToList();
        dto.Item.ItemContributors = dto.ContributorData.Select(cd => new ItemContributor
        {
            ContributorId = cd.Key,
            // Assuming the string is perhaps a role or something, but since not used in add, just create the link
        }).ToList();
        _items.Add(dto.Item);
    }
    return true;
});
```  