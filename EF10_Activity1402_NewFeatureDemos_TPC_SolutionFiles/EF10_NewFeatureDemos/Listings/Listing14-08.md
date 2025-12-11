# Listing 14-8: Toggle Active Filter for Categories

In this listing, you'll set the Toy/Collectable category active flag.  This will make it so that the `IsActive` toggle will keep inactive categories from showing.

## The code

```cs
var toyCategory = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryName == "Toy/Collectable");
if (toyCategory != null)
{
    toyCategory.IsActive = false;
    await _db.SaveChangesAsync();
}

//show the categories again (should not see the toy category now)
allCategories = await _db.Categories.ToListAsync();
Console.WriteLine(ConsolePrinter.PrintBoxedList(allCategories
    , c => $"{c.Id}: {c.CategoryName} [IS Deleted: {c.IsDeleted}] - [Is Active {c.IsActive}]"));

//toggle the filter to show inactive categories
List<Category> includeInactive = await _db.Categories
                                            .IgnoreQueryFilters(new[] { "Active" })
                                            .ToListAsync();
Console.WriteLine(ConsolePrinter.PrintBoxedList(includeInactive
    , c => $"{c.Id}: {c.CategoryName} [IS Deleted: {c.IsDeleted}] - [Is Active {c.IsActive}]"));
```  