# Listing 12-36: Test Get By Name

Ensure that the `GetByNameAsync_Finds_By_FilterName` test is implemented

## The Code  

```cs
//Listing 12-36 - Get Item By Name Async
var repo = new ItemRepository(_itf.Db);
var first = await _itf.Db.Items.FirstAsync();
var fetched = await repo.GetByIdAsync(first.Id);
fetched.ShouldNotBeNull();
fetched!.Id.ShouldBe(first.Id);
fetched.Name.ShouldBe(first.Name);
```  