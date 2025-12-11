# Listing 14-22: Using a LeftJoin greatly improves the report query

Using the new LeftJoin, the query generates the same TSQL but is much easier to read and understand as a developer.

## The Code

Use this code to implement the new way to get the Contributors with Items count report data

```cs
var query = _db.Contributors
    .LeftJoin(
        _db.ItemContributors,
        c => c.Id,
        ic => ic.ContributorId,
        (c, ic) => new { Contributor = c, ItemContributor = ic }
    )
    .GroupBy(x => x.Contributor)
    .Select(g => new
    {
        ContributorName = g.Key.ContributorName,
        ItemCount = g.Count(x => x.ItemContributor != null) // → 0 when none
    })
    .ToList();
```  