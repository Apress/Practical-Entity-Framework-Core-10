# Listing 7-27: Leverage the new function to get Item details

Add the code to execute the function.

## The code

Use the following code to get the results of the function call into a DbSet.

```cs
var itemDetails = await _db.Set<ItemWithCsvDetailsDTO>()
                        .FromSqlRaw("SELECT * FROM dbo.fnItemsWithCsvDetails()")
                        .OrderByDescending(x => x.TotalValue)
                        .ToListAsync();
```  