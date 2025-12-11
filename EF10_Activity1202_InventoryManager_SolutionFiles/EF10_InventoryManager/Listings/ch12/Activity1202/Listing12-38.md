# Listing 12-38: GetItemsByFilterAsync_Returns_Filtered_Items

Complete the Get Items By Filter test.

## The Code  

```cs
//Listing 12-38 - Get Items By Filter
var repo = new ItemRepository(_itf.Db);
var filter = "The"; // Example filter
var items = await repo.GetItemsByFilterAsync(filter);
items.ShouldNotBeNull();
items.ShouldAllBe(i => i.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));
```  