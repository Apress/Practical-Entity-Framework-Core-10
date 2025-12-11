# Listing 14-20: The Old way to get complex data sets

For this solution, you need to get all the contributors, show their item counts, and make sure to include even the contributors that have no items.

## The code

The old way to do this used GroupJoin, SelectMany, and GroupBy to get the data

```cs
var query = _context.Contributors
    .GroupJoin(
        _context.ItemContributors,
        c => c.Id,
        ic => ic.ContributorId,
        (c, ics) => new { Contributor = c, ItemContributors = ics }
    )
    .SelectMany(
        x => x.ItemContributors.DefaultIfEmpty(),
        (x, ic) => new { x.Contributor, ItemContributor = ic }
    )
    .GroupBy(x => x.Contributor)
    .Select(g => new
    {
        ContributorName = g.Key.ContributorName,
        ItemCount = g.Count(x => x.ItemContributor != null)  // counts items safely
    })
    .ToList();
```  

>**Note:** this code is already implemented and runs by default for the LINQ enhancements review.