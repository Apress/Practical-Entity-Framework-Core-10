# Listing 10-20: Always Encrypted for Deterministic Fields

Unfortunately, the `Name` field can't be ordered until it is decrypted.

## New Approach

First get the results in a decrypted fashion to the client, then order the data on the client-side

```cs
var items = await _db.Items.ToListAsync();
return items.OrderBy(x => x.Name).ToList();
```  