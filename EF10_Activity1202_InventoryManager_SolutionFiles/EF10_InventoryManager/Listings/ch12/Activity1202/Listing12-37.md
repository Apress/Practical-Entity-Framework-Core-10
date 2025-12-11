# Listing 12-37: GetItemByNameWithGenreByNameAsync_Returns_Item_With_Specific_Genre

Testing the ability to make sure that passing both an item name and genre name gets the correct item detail

## The Code  

```cs
//Listing 12-37: Get Item by Name and Genre Name
var repo = new ItemRepository(_itf.Db);
var itemName = "The Shawshank Redemption";
var genreName = "Drama";
var item = await repo.GetItemByNameWithGenreByNameAsync(itemName, genreName);
item.ShouldNotBeNull();
item!.Name.ShouldBe(itemName);
item.Genres.ShouldNotBeNull();
item.Genres.ShouldContain(g => g.GenreName == genreName);
```  