# Listing 14-18: The code to get results from Raw SQL directly to a known object

In the new approach, use SqlQuery to run the code to project the results into an object.

## Code

In this implementation, there is no need to set the HasNoKey value or map to a DbSet, just run the simple SqlQuery method:

```cs
itemsNewWay = await _db.Database
    .SqlQuery<ItemDetailSummaryDTO>(
        $"SELECT * FROM vwGetItemDetailSummaries")
    .ToListAsync();
```  