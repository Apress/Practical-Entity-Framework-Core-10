# Listing 8-17: Get the match without tracking

Use `AsNoTracking` when you want to work with data in a read-only fashion

## The code

The code to get the matching item with no tracking.

```cs
var itemDetailUpdated = await _db.Items
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Name == name);
```  
