# Listing 8-2 - Use Eager Loading

The use of Include means a join will be used by the query in the background, and only one call to the database is made.

## The code

```cs
var items = await _db.Items.Include(x => x.Category)
                                .ToListAsync();
foreach (var item in items)
{
    //no extra call since already loaded
    var categoryName = item.Category?.CategoryName ?? "No Category";
    Console.WriteLine($"{item.Name} is in category {categoryName}");
}
```  