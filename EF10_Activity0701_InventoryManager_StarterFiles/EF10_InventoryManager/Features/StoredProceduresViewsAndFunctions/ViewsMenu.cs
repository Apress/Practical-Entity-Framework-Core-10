using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.CRUD;

public class ViewsMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    public ViewsMenu(InventoryDbContext context, int lineLength)
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
                                "Views",
                                "Select a view to display:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    await GetContributorDetailsAsync();
                    break;
                case 2:
                    await GetFullItemDetailsAsync();
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
            "Get Contributor Details",
            "Get Items Details",
            "Back to Main Menu"
        };
    }

    //Implemented prior to activity 0701, do not alter this method
    private async Task GetContributorDetailsAsync()
    {
        Console.Clear();
        Console.WriteLine("Contributor Details View:");

        var contributors = await _db.ContributorSummaries
                                    .OrderBy(c => c.ContributorName)
                                    .ToListAsync();
        var output = ConsolePrinter.PrintBoxedList(contributors,
                                    c => $"ID: {c.ContributorId} | Name: {c.ContributorName} | Items: {c.ItemTitles}",
                                    "Contributor Details", _lineLength);
        //Console.WriteLine(output);
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }

    private async Task GetFullItemDetailsAsync()
    {
        Console.Clear();
        Console.WriteLine("Full Item Details View:");

        //*** Do Not Modify Above This Line *****/

        //TODO: Replace the next three lines with the text from Listing 7-35 
        var output = ConsolePrinter.PrintBoxedList(new List<String>() { "Not Implemented - See Activity 0703" }, x => x, "Full Item Details", _lineLength);  //replace
        Console.Clear(); // replace
        Console.WriteLine(output); //replace


        //*** Do Not Modify Below This Line *****/
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}