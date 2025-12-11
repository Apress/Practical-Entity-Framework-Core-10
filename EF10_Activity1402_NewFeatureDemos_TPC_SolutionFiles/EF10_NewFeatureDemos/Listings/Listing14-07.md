# Listing 14-7: Toggle Soft Delete Filter

In this sample, you'll see how to toggle the soft delete exclusion filter by name

## The Code

```cs
List<Category> allIncludingDeleted = await _db.Categories
    .IgnoreQueryFilters(new[] { "SoftDelete" })
    .ToListAsync();

Console.WriteLine(ConsolePrinter.PrintBoxedList(allIncludingDeleted
    , c => $"{c.Id}: {c.CategoryName} [IS Deleted: {c.IsDeleted}] - [Is Active {c.IsActive}]"));
```  