# Listing 8-1 - Use Lazy Loading

If you want to run this and get results, you'll need to enable the `UseLazyLoadingProxies()` in Program.cs on the context injection.

## The code

```cs
var items = await _db.Items.ToListAsync();
foreach (var item in items)
{
    //requires an additional database call on each iteration
    var categoryName = item.Category?.CategoryName ?? "No Category";
    Console.WriteLine($"{item.Name} is in category {categoryName}");
}
```  