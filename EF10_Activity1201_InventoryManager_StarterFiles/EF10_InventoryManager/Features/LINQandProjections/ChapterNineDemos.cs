using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.LINQandProjections;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
public class ChapterNineDemos
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    public ChapterNineDemos(InventoryDbContext context, int lineLength)
    {
        _db = context;
        _lineLength = lineLength;
    }

    private List<string> GetMenuOptions()
    {
        return new List<string>
        {
            "Anonymous Types",
            "Advanced Anonymous Types",
            "Projection on a defined Model",
            "Back to Main Menu"
        };
    }

    public async Task ShowAsync()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();

            var menuOptions = GetMenuOptions();
            var menuText = MenuGenerator.GenerateMenu(
                                "Demo Queries",
                                "Select a Query to Execute:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    await AnonymousTypes();
                    break;
                case 2:
                    await AdvancedAnonymousTypes();
                    break;
                case 3:
                    await ProjectionOnBackedModel();
                    break;
                case 4:
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private async Task AnonymousTypes()

    {
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
    }

    private async Task AdvancedAnonymousTypes()
    {
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
    }

    private async Task ProjectionOnBackedModel()
    {
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
    }
}
