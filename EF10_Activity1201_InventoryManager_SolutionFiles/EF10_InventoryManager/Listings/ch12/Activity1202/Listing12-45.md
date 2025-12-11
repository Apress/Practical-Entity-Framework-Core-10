# Listing 12-45: Delete Async

Use the following code to implement the Delete Async method

## The Code  

```cs
//Listing 12-45: Delete Async
var repo = new ItemRepository(_itf.Db);

var allItems = await repo.GetAllAsync();
var existing = allItems.Last();
var success = await repo.DeleteAsync(existing.Id);

success.ShouldBeTrue();
var exists = await repo.GetByIdAsync(existing.Id) != null;
exists.ShouldBeFalse();
```  