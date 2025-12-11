# Listing 12-05: Make sure the reverse navigations work too

In order to fully test, the system should have all relations set as expected.

## The Code

Add the following code to replace the line `//more code to set up objects will go here`

```cs
// Make sure relationships are set in both directions
foreach (var category in _categories)
{
    category.Items = _items.Where(i => i.CategoryId == category.Id).ToList();
}
foreach (var genre in _genres)
{
    genre.Items = _items.Where(i => i.Genres != null && i.Genres.Any(g => g.Id == genre.Id)).ToList();
}
foreach (var contributor in _contributors)
{
    contributor.ItemContributors = _itemContributors.Where(ic => ic.ContributorId == contributor.Id).ToList();
}
foreach (var item in _items)
{
    if (item.ItemContributors != null)
    {
        foreach (var ic in item.ItemContributors)
        {
            ic.Item = item;
            ic.Contributor = _contributors.FirstOrDefault(c => c.Id == ic.ContributorId);
        }
    }
}

//Setup Mocks for the Generic Repository methods used in ItemService

//Setup Mocks for the Custom Repository methods used in ItemService 

```  