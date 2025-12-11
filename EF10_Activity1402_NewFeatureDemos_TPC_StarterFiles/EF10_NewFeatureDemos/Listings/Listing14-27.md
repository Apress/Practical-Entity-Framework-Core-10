# Listing 14-27: Get all the Items from the TPC hierarchy

Show the Items

## The code

This query runs and pulls all the Items from all tables in the hierarchy, inclufing Items, Books, and Movies

```cs
var items = await _db.Items
    .AsNoTracking()
    .Select(i => new
    {
        i.Id,
        i.ItemName,
        i.Description,
        CategoryName = i.Category.CategoryName,
        i.IsOnSale
    }).ToListAsync();
```  