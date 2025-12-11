# Listing 12-36: Test Get By Name

Ensure that the `GetByNameAsync_Finds_By_FilterName` test is implemented

## The Code  

```cs
var repo = new ItemRepository(_itf.Db);
var first = await _itf.Db.Items.FirstAsync();
var fetched = await repo.GetByNameAsync(first.Name);
fetched.ShouldNotBeNull();
fetched!.Id.ShouldBe(first.Id);
fetched.Name.ShouldBe(first.Name);
```  