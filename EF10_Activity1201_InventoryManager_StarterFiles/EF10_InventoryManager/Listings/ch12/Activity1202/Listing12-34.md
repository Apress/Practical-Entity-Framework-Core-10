# Listing 12-34: Test Get All Async

Use this code to implement the test `GetAllAsync_Returns_All_Items` returns all the items from the datatbase.

## The Code  

```cs
//Listing 12-34: Get All Async
var repo = new ItemRepository(_itf.Db);

var all = await repo.GetAllAsync();

all.Count.ShouldBeGreaterThanOrEqualTo(11); //based on seeddata.cs
all.ShouldAllBe(c => !string.IsNullOrWhiteSpace(c.Name));
```  