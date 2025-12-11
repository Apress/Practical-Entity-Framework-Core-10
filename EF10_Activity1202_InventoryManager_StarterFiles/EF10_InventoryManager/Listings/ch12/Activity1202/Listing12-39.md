# Listing 12-39: TestGetAllItemsWithCategoryAsync

The next test is to get the Item data and include the Category

## The Code  

```cs
//Listing 12-39 - Get All items with their category included
var repo = new ItemRepository(_itf.Db);
var itemsWithCategory = await repo.GetAllItemsWithCategoryAsync();
itemsWithCategory.ShouldNotBeNull();
itemsWithCategory.ShouldAllBe(i => i.Category != null);
itemsWithCategory.Count.ShouldBeGreaterThanOrEqualTo(50); // Based on seed data
```  