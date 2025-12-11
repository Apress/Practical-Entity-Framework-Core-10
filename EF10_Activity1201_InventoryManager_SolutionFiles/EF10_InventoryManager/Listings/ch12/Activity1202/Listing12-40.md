# Listing 12-40: Testing the Find Async method

Test the ability to use a filter to find any matching Item(s).

## The Code  

```cs
//Listing 12-40 - Find Async
var repo = new ItemRepository(_itf.Db);
var results = await repo.FindAsync(c => c.Name.Contains("ovi"));
results.ShouldNotBeNull();
results.ShouldAllBe(c => c.Name.Contains("ovi"));
```  