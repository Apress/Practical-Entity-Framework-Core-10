# Listing 14-14: Getting the data by filter on the properties for an entity stored as JSON

With the new JSON improvements, you can now leverage an owned entity and query the properties without creating a table or bringing the JSON string to the client-side.

## The code

Use the code here to get the contributors that live in one of the cities, filtering by city name

```cs
var cityToFind = "Lakeside";

contributorsInCity = await _db.Contributors
    .Where(c => c.Address != null 
            && c.Address.City == cityToFind)
    .ToListAsync();
```  

