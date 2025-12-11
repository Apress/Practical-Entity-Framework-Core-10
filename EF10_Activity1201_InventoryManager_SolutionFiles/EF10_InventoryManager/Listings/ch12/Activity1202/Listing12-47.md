# Listing 12-47: Testing the code with a unit of work

Use this code to implement the final test that rollsback any changes if the transaction fails.

## The Code  

```cs
var repo = new ItemRepository(_itf.Db);
var beforeItems = await repo.GetAllAsync();
var itemCount = beforeItems.Count();
string userId = "cdd68205-0311-4f1b-9d43-c3c76c8bb3df";
DateTime today = DateTime.UtcNow;
var item1 = new Item()
{
    Name = "Bulk Item 1"
    , CategoryId = 1
    , Description = "Bulk Item 1 Description"
    , IsActive = true
    , Genres = new List<Genre>()
    , CreatedByUserId = userId
    , CreatedDate = today
};
var item2 = new Item()
{
    Name = "Bulk Item 2"
    , CategoryId = 2
    , Description = "Bulk Item 2 Description"
    , IsActive = true
    , Genres = new List<Genre>()
    , CreatedByUserId = userId
    , CreatedDate = today
};

var contributorDetails1 = new Dictionary<int, string>();
contributorDetails1.Add(1, "Actor");

var contributorDetails2 = new Dictionary<int, string>();
contributorDetails2.Add(2, "Musician");

//item 1 should add
//item 2 should fail due to invalid genre ids, so nothing should be added
var items = new List<ParsedItemDataDTO>
{
    new ParsedItemDataDTO { Item = item1, ContributorData = contributorDetails1
                            , GenreIds = new List<int>() {1, 2, 3 } },
    new ParsedItemDataDTO { Item = item2, ContributorData = contributorDetails2
                            , GenreIds = new List<int>() {75, 99, 131 } }
};

var success = false;
try
{
    success = await repo.BulkLoadItemDataAsync(items);
}
catch (System.Exception ex)
{
    // Should fail due to invalid genre ids, and rollback
    success.ShouldBeFalse();
}
 
var afterItems = await repo.GetAllAsync();
afterItems.Count().ShouldBe(itemCount); // No new items should be added
```  