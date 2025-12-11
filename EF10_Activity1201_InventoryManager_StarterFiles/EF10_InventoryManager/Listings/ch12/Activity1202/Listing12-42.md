# Listing 12-42: Add Async: Part two

Use the following code to test the Add Async, as well as:
- `GetItemByNameWithCategoryAsync`
- `GetItemByNameWithGenreAsync`

## The Code  

```cs
result.ShouldBeTrue();
var reloaded = await repo.GetByNameAsync(toAdd.Name);
reloaded.ShouldNotBeNull();
reloaded!.Name.ShouldBe(toAdd.Name);

//tests Task<Item?> GetItemByNameWithCategoryAsync(string name);
var itemDetail = await repo.GetItemByNameWithCategoryAsync(toAdd.Name);
itemDetail.ShouldNotBeNull();
itemDetail!.Category.ShouldNotBeNull();
itemDetail!.Category.CategoryName.ShouldBe(movieCategory?.CategoryName);

//tests Task<Item?> GetItemByNameWithGenreAsync(string name);
itemDetail = await repo.GetItemByNameWithGenreAsync(toAdd.Name);
itemDetail.ShouldNotBeNull();
itemDetail!.Genres.ShouldNotBeNull();
itemDetail!.Genres.Count.ShouldBeGreaterThanOrEqualTo(2);
itemDetail!.Genres.ShouldContain(g => g.GenreName == genre1.GenreName);
itemDetail!.Genres.ShouldContain(g => g.GenreName == genre2.GenreName);

```  