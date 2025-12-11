# Listing 8-4 - Query with sorting

The use of ToList() before sorting/filtering results in client side inefficient operations

## The code

```cs
var items = await _db.Items.OrderByDescending(x => x.Name).ToListAsync();
Console.Clear();
foreach (var item in items)
{
    Console.WriteLine($"Item {item.Name}");
}
```  