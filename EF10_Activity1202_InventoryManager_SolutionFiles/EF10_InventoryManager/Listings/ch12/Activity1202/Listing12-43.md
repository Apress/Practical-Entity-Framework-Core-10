# Listing 12-43: Test Update an Item

Use the following code to test updating an item.

>**Note**: In the interest of brevity, not every field is tested.  In the real-world, you'd need to test that all fields are properly tested to avoid issues from pointing to the wrong field or forgetting to map a field.

## The Code  

```cs
//Listing 12-43: Testing Update an Item
var repo = new ItemRepository(_itf.Db);

var allItems = await repo.GetAllAsync();
var existing = allItems.First();
existing.Name = "UPDATED ITEM NAME";
var success = await repo.UpdateAsync(existing);

success.ShouldBeTrue();
var reloaded = await repo.GetByIdAsync(existing.Id);
reloaded!.Name.ShouldBe("UPDATED ITEM NAME");
```  