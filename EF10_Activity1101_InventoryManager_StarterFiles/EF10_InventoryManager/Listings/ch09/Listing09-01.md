# Listing 9-1: Simple Anonymous Type Projection 

Use of Anonymous Types to Project Specific Properties from Related Entities
Specifically, projecting properties from a related Category entity when querying Items.

## The code

```cs
string categoryFilter = "Some Category";

var itemsWithCategories = _db.Items
        .OrderBy(x => x.Category.CategoryName)
        .Select(item => new  
        {
            item.Id,
            ItemName = item.Name,
            CategoryId = item.CategoryId,
            CategoryName = item.Category.CategoryName
        })
        .ToList();
```  

## The full Example from the demo program

Here is the complete example, which is also implemented in option 10, then option 1 of the Inventory Manager application.

```cs  
//Listing 9-1
Console.Clear();
Console.WriteLine("Anonymous Types Demo");
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

foreach (var item in itemsWithCategories)
{
    Console.WriteLine(ConsolePrinter.PrintFormattedMessage($"ID: {item.Id}] Item: {item.ItemName}",
        $"{item.CategoryName} ({item.CategoryId})", _lineLength));
}

Console.WriteLine("\nPress any key to return to the menu...");
Console.ReadKey();
```  