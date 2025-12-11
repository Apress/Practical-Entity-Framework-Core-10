# Listing 12-44: Update Range of Items

The following code tests to validate that you can update a range of items in one operation.

## The Code  

```cs
//Listing 12-44 - update range
var repo = new ItemRepository(_itf.Db);
var allItems = await repo.GetAllAsync();
allItems.ShouldNotBeNull();
allItems.Count.ShouldBeGreaterThan(0);
// Modify items for update
foreach (var item in allItems)
{
    item.Description = $"{item.Description} - Updated {DateTime.UtcNow}";
    item.IsOnSale = true; // Example modification
}
var result = await repo.UpdateRangeAsync(allItems);
result.ShouldBeGreaterThan(0); // Should return number of updated records
// Verify updates
foreach (var item in allItems)
{
    var updatedItem = await repo.GetByIdAsync(item.Id);
    updatedItem!.Description?.ShouldContain("Updated");
    updatedItem!.IsOnSale.ShouldBeTrue();
}
```  