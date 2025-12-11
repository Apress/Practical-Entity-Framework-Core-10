using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.CRUD;

public class FunctionsMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    public FunctionsMenu(InventoryDbContext context, int lineLength)
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
                                "Functions",
                                "Select a function to execute:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    await ExecuteCalculateItemValueAsync();
                    break;
                case 2:
                    await ExecuteGetTopValueItemsAsync();
                    break;
                case 3:
                    await GetContributorScoreLeaderBoardAsync();
                    break;
                case 4:
                    await GetItemsWithCSVDetails();
                    break;
                case 5:
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
            "Calculate Item Value",
            "Get Top Value Items",
            "Get Contributor Leader Board",
            "Get Items - Complete Details",
            "Back to Main Menu"
        };
    }

    //Added prior to Activity 0701, do not alter this method
    private async Task ExecuteCalculateItemValueAsync()
    {
        Console.Clear();
        var items = await _db.Items.ToListAsync();
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id}: {item.Name}");
        }
        var itemId = UserInput.GetInputFromUser("Which item would you like to calculate the value for [Enter the ID number]", true, 1, items.Count);
        var selectedItem = items.FirstOrDefault(i => i.Id == itemId);
        if (selectedItem == null)
        {
            Console.WriteLine("Invalid item ID. Please try again.");
            return;
        }
        //use the input from the user to get the item value using the function
        var param = new SqlParameter("@itemId", itemId);
        var query = $"Select dbo.fnCalculateItemValue({param.Value}) AS ItemValue";

        var itemValue = await _db.Database
                            .SqlQueryRaw<decimal>($"{query}")
                            .AsAsyncEnumerable()
                            .FirstAsync();

        var details = ConsolePrinter.PrintFormattedMessage($"The value of the item with ID {selectedItem.Id}, " +
                            $"Name: {selectedItem.Name}, " +
                            $"Quantity: {selectedItem.Quantity}, " +
                            $"CurrentValue: {selectedItem.CurrentValue}, " +
                            $"Is: [{itemValue:C2}]", "Calculate Item Value Result", _lineLength);
        Console.WriteLine(details);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    //Added prior to Activity 0701, do not alter this method
    private async Task ExecuteGetTopValueItemsAsync()
    {
        Console.Clear();

        var topCount = UserInput.GetInputFromUser(
            "How many top value items would you like to see?", true, 1, 100);

        var items = await _db.Database
                            .SqlQueryRaw<TopValuedItemDTO>(
                                $"SELECT * FROM dbo.fnTopValuedItems({topCount})")
                            .ToListAsync();

        var output = ConsolePrinter.PrintBoxedList(items, i => $"VALUE: {i.TotalValue:C2} | Item {i.ItemId} | {i.ItemName}", "Top-Valued Items", _lineLength);
        Console.WriteLine(output);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    //Will be modified in Activity 0702, do not alter this method until then
    private async Task GetContributorScoreLeaderBoardAsync()
    {
        Console.Clear();
        Console.WriteLine("Getting Contibutors by score for the leaderboard:");

        //*** Do not alter above this line *****//

        //TODO: Use Listing 7-19 to get the contributor scores
        Console.WriteLine("Not yet implemented - see Activity 0702");

        //*** Do not alter below this line, just uncomment *****//
        //Console.Clear();
        //var output = ConsolePrinter.PrintBoxedList(contributors,
        //                            c => $"Rank: {c.RankPosition} | ID: {c.ContributorId} | Name: {c.ContributorName} | Score: {c.ContributorScore}",
        //                            "Contributor Leaderboard", _lineLength);
        //Console.WriteLine(output);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    //Will be modified in Activity 0702, do not alter this method until then
    private async Task GetItemsWithCSVDetails()
    {
        Console.Clear();
        Console.WriteLine("Getting Items with CSV details...");
        //*** Do not alter above this line *****//

        //TODO: Use the code in Listing 7-27 to get the items with CSV details
        Console.WriteLine("Not yet implemented - see Activity 0702");

        //*** DO not alter below this line, just uncomment *****//
        //Console.Clear();
        //Console.WriteLine("Top Value Items:");
        //var output = ConsolePrinter.PrintBoxedList(itemDetails,
        //                            i => $"Item ID {i.ItemId} | " +
        //                            $"Item Name: {i.ItemName} | " +
        //                            $"Category: {i.Category} | " +
        //                            $"Genres: {i.GenresCsv} |" +
        //                            $"Contributors: {i.ContributorsCsv} ",
        //                            "Item Details", _lineLength);
        //Console.WriteLine(output);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
