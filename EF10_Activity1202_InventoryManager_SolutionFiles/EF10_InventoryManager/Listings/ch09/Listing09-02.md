# Listing 9-2: Advanced Work with an Anonymous Type Projection 

Further projection and manipulation of the anonymous type created in Listing 9-1. 

## The code

This example demonstrates how to group items by category and display them in a formatted manner.

```cs
// Assuming itemsWithCategories is defined as in Listing 9-1
// 
var distinctCategories = itemsWithCategories
                            .Select(x => x.CategoryName) 
                            .Distinct()
                            .ToList();
foreach (var category in distinctCategories)
{
    var itemsInCategory = itemsWithCategories
                            .Where(x => x.CategoryName == category)
                            .OrderBy(x => x.ItemName)
                            .Select(x => new { x.ItemName, x.Id })
                            .ToList();

    Console.WriteLine(ConsolePrinter.PrintBoxedList(itemsInCategory
                                                    , x => $"{x.Id}] {x.ItemName}"
                                                    , $"{category}"
                                                    , _lineLength));
}
```

## The complete example  

Here is the full example, which is also implemented in option 10, then option 2 of the Inventory Manager application.  

```cs  
Console.Clear();
Console.WriteLine("Advanced Anonymous Types Demo");
Console.WriteLine("Fetching items with their categories...");
//get all the items and their categories
var itemsWithCategories = _db.Items.OrderBy(x => x.Category.CategoryName)
                            .Select(item => new
                            {
                                item.Id,
                                ItemName = item.Name,
                                CategoryId = item.CategoryId,
                                CategoryName = item.Category.CategoryName ?? "Category Not Loaded"
                            })
                            .ToList();

//listing 9-2
// Group items by category
var distinctCategories = itemsWithCategories
                            .Select(x => x.CategoryName)
                            .Distinct()
                            .ToList();
foreach (var category in distinctCategories)
{
    // For each category, get items in that category
    var itemsInCategory = itemsWithCategories
                            .Where(x => x.CategoryName == category)
                            .OrderBy(x => x.ItemName)
                            .Select(x => new { x.ItemName, x.Id })
                            .ToList();

    // Print the category and its items
    Console.WriteLine(ConsolePrinter.PrintBoxedList(itemsInCategory
                                                    , x => $"{x.Id}] {x.ItemName}"
                                                    , $"{category}"
                                                    , _lineLength));
}

Console.WriteLine("\nPress any key to return to the menu...");
Console.ReadKey();
```  