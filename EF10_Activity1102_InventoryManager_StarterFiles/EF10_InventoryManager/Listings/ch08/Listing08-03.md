# Listing 8-3 - Query then filter

The use of ToList() before sorting/filtering results in client side inefficient operations

## The code

```cs
var items = await _db.Items.ToListAsync();
items = items.OrderByDescending(x => x.Name).ToList(); //requires another call to ToList() to make the sort happen
Console.Clear();
foreach (var item in items)
{
    Console.WriteLine($"Item {item.Name}");
}
```  