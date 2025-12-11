# Listing 12-35: Test GetByIdAsync_Returns_Single_Item 

Ensure that the ability to get an Item by Id is working.

## The Code  

```cs
//Listing 12-35 - Get by Id
var repo = new ItemRepository(_itf.Db);

var first = await _itf.Db.Items.FirstAsync();
var fetched = await repo.GetByIdAsync(first.Id);

fetched.ShouldNotBeNull();
fetched!.Id.ShouldBe(first.Id);
fetched.Name.ShouldBe(first.Name);
```  