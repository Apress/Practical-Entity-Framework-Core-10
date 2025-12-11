# Listing 12-04: Create the List data from the StaticTestingHelpers class

Use the `StaticTestingHelpers` class to populate the data into `Lists` for use in your mocking calls

## The Code

Place this code in the constructor right after declaring the MOCK object

```cs
// Create per-test copies of stub data to avoid shared state issues
_genres = StaticTestingHelpers.Genres
            .Select(g => new Genre { Id = g.Id, GenreName = g.GenreName, Items = new List<Item>() })
            .ToList();
_categories = StaticTestingHelpers.Categories
                .Select(c => new Category { Id = c.Id, CategoryName = c.CategoryName, Items = new List<Item>() })
                .ToList();
_contributors = StaticTestingHelpers.Contributors
                    .Select(con => new Contributor { Id = con.Id, ContributorName = con.ContributorName
                        , ItemContributors = new List<ItemContributor>() })
                    .ToList();
_itemContributors = StaticTestingHelpers.ItemContributors
                        .Select(ic => new ItemContributor { ItemId = ic.ItemId, ContributorId = ic.ContributorId })
                        .ToList();
_items = StaticTestingHelpers.Items.Select(i => new Item
{
    Id = i.Id,
    Name = i.Name,
    CategoryId = i.CategoryId,
    Category = _categories.FirstOrDefault(c => c.Id == i.CategoryId),
    Genres = i.Genres?.Select(g => _genres.FirstOrDefault(gg => gg.Id == g.Id)).ToList(),
    ItemContributors = i.ItemContributors?
        .Select(ic => new ItemContributor { ItemId = ic.ItemId, ContributorId = ic.ContributorId })
        .ToList()
}).ToList();

//more code to set up objects will go here
```  