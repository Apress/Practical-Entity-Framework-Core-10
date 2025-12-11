# Listing 8-16: Use the default query to get a record that is tracked

By default, tracking is on, which means you don't have to do anything to get the data in a way that changes are tracked in memory.

## The code

The code to get the matching item with tracking

```cs
var itemDetail = await _db.Items.FirstOrDefaultAsync(x => x.Name == name);
```  
