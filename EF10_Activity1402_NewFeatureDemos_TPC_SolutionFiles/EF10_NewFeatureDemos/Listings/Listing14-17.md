# Listing 14-17: Using an anonymous projection from a query to an unknown entity

Another way to get data FromSqlRaw was to project each field directly to an anoymous type.

## The Code

In this case, you could run just about any query and get the data into an anonymous type, which gave a lot of flexibility in unique scenarios where using a keyless entity was too much overhead

```cs
var results = await _context.Items
    .FromSqlRaw(@"
        SELECT i.Id, i.Name, c.CategoryName
        FROM Items i
        INNER JOIN Categories c ON i.CategoryId = c.Id
    ")
    .Select(i => new 
    { 
        ItemName = i.Name, 
        CategoryName = i.Category.CategoryName 
    })
    .ToListAsync();
```  

>**NOTE:** You are not implementing this code anywhere, it is for review/learning purposes only.