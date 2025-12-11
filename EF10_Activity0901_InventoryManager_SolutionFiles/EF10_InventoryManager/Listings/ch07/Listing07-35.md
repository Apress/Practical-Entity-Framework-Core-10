# Listing 7-35

Code to get results using the view from three separate calls to show the power of using the view.

## code

It's tedious and it's long, but here is the code to get three different datasets using the same view.

```cs
Console.Clear();
var query = "SELECT * FROM vwItemsWithGenresAndContributors";
var items1 = await _db.Set<ItemDetailSummaryDTO>()
                            .FromSqlRaw(query)
                            .OrderBy(i => i.ItemName)
                            .ToListAsync();
var output1 = ConsolePrinter.PrintBoxedList(items1,
                            i => $"Item ID {i.ItemId} | " +
                            $"Item Name: {i.ItemName} | " +
                            $"Category: {i.CategoryName} | " +
                            $"Genres: {i.Genres} |" +
                            $"Contributors: {i.Contributors} | " +
                            $"Total Value: {i.TotalValue} ",
                            "Item Details", _lineLength);
Console.Clear();
Console.WriteLine(output1);
Console.WriteLine("\nPress any key to continue...");
Console.ReadKey();
Console.Clear();
var items2 = await _db.Set<ItemDetailSummaryDTO>()
                            .FromSqlRaw(query)
                            .Where(x => x.Genres.Contains("Action"))
                            .OrderBy(i => i.ItemName)
                            .ToListAsync();
var output2 = ConsolePrinter.PrintBoxedList(items2,
                            i => $"Item ID {i.ItemId} | " +
                            $"Item Name: {i.ItemName} | " +
                            $"Category: {i.CategoryName} | " +
                            $"Genres: {i.Genres} |" +
                            $"Contributors: {i.Contributors} |" +
                            $"Total Value: {i.TotalValue} ",
                            "Item Details", _lineLength);

Console.Clear();
Console.WriteLine(output2);
Console.WriteLine("\nPress any key to continue...");
Console.ReadKey();
Console.Clear();
var items3 = await _db.Set<ItemDetailSummaryDTO>()
                            .FromSqlRaw(query)
                            .Where(x => x.Genres.Contains("Action"))
                            .OrderByDescending(x => x.TotalValue)
                            .ToListAsync();
var output3 = ConsolePrinter.PrintBoxedList(items3,
                            i => $"Total Value: {i.TotalValue} | " +
                            $"Item ID {i.ItemId} | " +
                            $"Item Name: {i.ItemName} | " +
                            $"Category: {i.CategoryName} | " +
                            $"Genres: {i.Genres} |" +
                            $"Contributors: {i.Contributors} ",
                            "Item Details", _lineLength);
Console.Clear();
Console.WriteLine(output3);
```  