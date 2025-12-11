using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.CRUD;

public class ProceduresMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    public ProceduresMenu(InventoryDbContext context, int lineLength)
    {
        _db = context;
        _lineLength = lineLength;
    }

    public async Task ShowAsync()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();

            var menuOptions = GetMenuOptions();
            var menuText = MenuGenerator.GenerateMenu(
                                "Stored Procedures",
                                "Select a stored procedure to execute:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    await ExecuteGetItemsByCategoryAsync();
                    break;
                case 2:
                    await ExecuteGetItemsByGenreAsync();
                    break;
                case 3:
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    private List<string> GetMenuOptions()
    {
        return new List<string>
        {
            "Get Items by Category",
            "Get Items by Genre",
            "Back to Main Menu"
        };
    }

    /// <summary>
    /// Added prior to activity 0701, do not alter this method
    /// </summary>
    /// <returns></returns>
    private async Task ExecuteGetItemsByCategoryAsync()
    {
        Console.Clear();
        Console.WriteLine("Executing GetItemsByCategory stored procedure...");

        var items = await _db.ItemsByCategory
            .FromSqlRaw("EXEC GetItemsByCategory 'Movie'")
            .ToListAsync();

        Console.Clear();
        Console.WriteLine("Items retrieved successfully:");

        Console.WriteLine(ConsolePrinter.PrintBoxedList(
                                    items,
                                    i => $"(ID: {i.Id}) {i.Id}| Name: {i.Name}| Category: {i.CategoryName} | CategoryId: {i.CategoryId}",
                                    "List of Contributors"
                                ));

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task ExecuteGetItemsByGenreAsync()
    {
        Console.Clear();
        Console.WriteLine("Executing GetItemsByGenre stored procedure...");

        var items = new List<string>() { "Not Implemented. Remove the blank items (this line) and uncomment the remaining code to execute the stored procedure." };
        Console.WriteLine(ConsolePrinter.PrintBoxedList(items, x => x, "Not Implemented", _lineLength));
        //TODO: Remove the two lines above this one, and then uncomment the following code to execute the stored procedure
        //var items = await _db.ItemsByGenre
        //    .FromSqlRaw("EXEC GetItemsByGenre 'Action', 1")
        //    .ToListAsync();

        //Console.Clear();
        //Console.WriteLine("Items retrieved successfully:");
        ////NOTE: IF you get an error, modify this line to match your DTO properties
        //Console.WriteLine(ConsolePrinter.PrintBoxedList(
        //                            items,
        //                            i => $"(ID: {i.ItemId}) " +
        //                                    $"{i.ItemName}| " +
        //                                    $"Genre: {i.GenreName} | " +
        //                                    $"GenreId: {i.GenreId} |, " +
        //                                    $"IsActive: {i.IsActive} |" +
        //                                    $"Description: {i.ItemDescription}",
        //                            "List of Items by Genre"
        //                        ));

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }


}