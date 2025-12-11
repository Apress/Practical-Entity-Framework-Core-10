# Listing 9-3: Projection on a known Type

Get results from the view, then project them to an anonymous type with limited properties.

## The code

This example gets the results of the view and then further limits the data for use on the UI.

```cs
var query = "SELECT * FROM vwItemsWithGenresAndContributors";
var itemDetails = await _db.Set<ItemDetailSummaryDTO>()
                            .FromSqlRaw(query)
                            .OrderBy(i => i.CategoryName)
                            .ToListAsync();

var contributorName = "John Williams";

var itemsForContributor = itemDetails
    .Where(i => i.Contributors.Contains(contributorName))
    .Select(i => new
    {
        i.ItemId,
        i.ItemName,
        i.CategoryName
    })
    .ToList();

Console.WriteLine(ConsolePrinter.PrintBoxedList(itemsForContributor,
                            i => $"{i.ItemId}] {i.ItemName} ({i.CategoryName})",
                            $"Items for Contributor: {contributorName}",
                            _lineLength));
``` 

## The complete example

Here is the full example, which is also implemented in option 10, then option 3 of the Inventory Manager application.  

```cs  
//Listing 9-3  
Console.Clear();
Console.WriteLine("Further Manipulation on Known Types");
Console.WriteLine("Fetching Item Detail Summaries...");
var query = "SELECT * FROM vwItemsWithGenresAndContributors";
var itemDetails = await _db.Set<ItemDetailSummaryDTO>()
                            .FromSqlRaw(query)
                            .OrderBy(i => i.CategoryName)
                            .ToListAsync();

var contributorName = "John Williams";

var itemsForContributor = itemDetails
    .Where(i => i.Contributors.Contains(contributorName))
    .Select(i => new
    {
        i.ItemId,
        i.ItemName,
        i.CategoryName
    })
    .ToList();

Console.WriteLine(ConsolePrinter.PrintBoxedList(itemsForContributor,
                            i => $"{i.ItemId}] {i.ItemName} ({i.CategoryName})",
                            $"Items for Contributor: {contributorName}",
                            _lineLength));

Console.WriteLine("\nPress any key to return to the menu...");
Console.ReadKey();
```  