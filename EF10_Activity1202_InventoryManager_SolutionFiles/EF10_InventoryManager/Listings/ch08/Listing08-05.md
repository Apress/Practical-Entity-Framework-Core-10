# Listing 8-5 - AsNoTracking

Using AsNoTracking() to disconnect the results from the tracking context.

## The code

```cs
var items = await _db.Items
                        .OrderByDescending(x => x.Name)
                        .AsNoTracking()
                        .ToListAsync();

```  