# Listing 14-15: Getting the data by filter on the properties for an entity stored as JSON (part 2)

With the new JSON improvements, you can now leverage an owned entity and query the properties without creating a table or bringing the JSON string to the client-side.

## The code

This code is able to get the contributors that have an address where the first line of the address is a PO Box.

```cs
contributorsWithPOBox = await _db.Contributors
    .Where(c => c.Address != null && c.Address.AddressLine1 
            != null && c.Address.AddressLine1.StartsWith("PO Box"))
    .ToListAsync();
```  
