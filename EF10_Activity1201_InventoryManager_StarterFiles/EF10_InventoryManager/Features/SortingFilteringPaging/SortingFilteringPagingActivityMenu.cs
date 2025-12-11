using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.SortingFilteringPaging;

public class SortingFilteringPagingActivityMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    public SortingFilteringPagingActivityMenu(InventoryDbContext context, int lineLength)
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
                                "Sorting, Filtering, Paging, and more",
                                "Select a Query to Execute:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            List<Item> items = new List<Item>();
            string output = string.Empty;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Getting Items To List, then Order, then Take");
                    items = await ListItemsThenOrderAndTake();
                    output = ConsolePrinter.PrintBoxedList(items, x => $"Name: {x.Name}| Desc: {x.Description}", "Items Ordered, then Take, then To List", _lineLength);
                    Console.WriteLine(output);
                    WaitForUserResponse();
                    break;
                case 2:
                    Console.WriteLine("Ordering Items, Take, then ToList");
                    items = await OrderItemsThenTakeAndList();
                    output = ConsolePrinter.PrintBoxedList(items, x => $"Name: {x.Name}| Desc: {x.Description}", "Items Ordered, then Take, then To List", _lineLength);
                    Console.WriteLine(output);
                    WaitForUserResponse();
                    break;
                case 3:
                    Console.WriteLine("Filtering by Item Name or Contributor Name");
                    var userInput = UserInput.GetInputFromUser("Enter any part of the item you want to search for (case-insensitive):", shouldConfirm: true);
                    items = await FilterItemsByUserInput(userInput);
                    output = ConsolePrinter.PrintBoxedList(items, x => $"ID: {x.Id}] Name: {x.Name}| Description {x.Description}", "Using LINQ and EF Functions for raw filter", _lineLength);
                    Console.WriteLine(output);
                    WaitForUserResponse();
                    break;
                case 4:
                    Console.WriteLine("Filtering and Match Using the View");
                    var viewFilter = UserInput.GetInputFromUser("Enter any part of the item you want to search for (case-insensitive):", shouldConfirm: true);
                    var itemDetails = await FilterItemsByUserInputUsingView(viewFilter);
                    output = ConsolePrinter.PrintBoxedList(itemDetails, x => $"ID: {x.ItemId}] Name: {x.ItemName}| Contributors: {x.Contributors}", "Using the View To Filter with LINQ and EF Functions", _lineLength);
                    Console.WriteLine(output);
                    WaitForUserResponse();
                    break;
                case 5:
                    Console.WriteLine("Filter/Match and Page Results");
                    var viewPageFilter = UserInput.GetInputFromUser("Enter any part of the item you want to search for (case-insensitive):", shouldConfirm: true);
                    await FilterItemsByUserInputUsingViewAndPaging(viewPageFilter);
                    WaitForUserResponse();
                    break;
                case 6:
                    Console.WriteLine("Using AsNoTracking to Disconnect Results");
                    await RunAsNoTrackingDemo();
                    WaitForUserResponse();
                    break;
                case 7:
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void WaitForUserResponse()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task<List<Item>> ListItemsThenOrderAndTake()
    {
        //Get all the items first, ten order them, then take the first 25
        //This is not efficient, but it demonstrates the concept of ordering after getting a list

        //Replaced with code from Listing 8-6

        //Get all the items first, ten order them, then take the first 25
        //This is not efficient, but it demonstrates the concept of ordering after getting a list
        var items = await _db.Items.ToListAsync();      //IEnumerable<Item>, so no ordering yet, moved to client-side
        items = items.OrderByDescending(x => x.Name)    //IOrderedEnumerable<Item>, so still client-side
                        .Take(25)                       //IEnumerable<Item>, so still client-side
                        .ToList();                      //Make it to a list again.
        return items;
        return items;
    }

    private async Task<List<Item>> OrderItemsThenTakeAndList()
    {
        //Order the items, limit to 25, then convert to a list
        //This is more efficient as it uses the database to do the ordering and limiting

        //Replaced with code from Listing 8-7
        //Order the items, limit to 25, then convert to a list
        //This is more efficient as it uses the database to do the ordering and limiting
        var items = await _db.Items.OrderByDescending(x => x.Name)     //IOrderedQueryable<Item>
                                .Take(25)                              //IQueryable<Item>, so no ToList() yet, still server-side
                                .ToListAsync();                        //now IEnumerable<Item>
        return items;
    }

    private async Task<List<Item>> FilterItemsByUserInput(string userInput)
    {
        //Filter items by user input, case insensitive, for item name or contributor name and return as a list

        //Replaced with code from Listing 8-10
        //Filter items by user input, case insensitive, and return as a list
        var filter = $"%{userInput}%";
        var items = await _db.Items.Include(i => i.ItemContributors)
                                    .ThenInclude(ic => ic.Contributor)
                                    .Where(i => EF.Functions.Like(i.Name ?? "", filter)
                                        || i.ItemContributors.Any(ic =>
                                            ic.Contributor != null &&
                                            EF.Functions.Like(ic.Contributor.ContributorName ?? "", userInput)))
                                    .ToListAsync();
        return items;
    }

    private async Task<List<ItemDetailSummaryDTO>> FilterItemsByUserInputUsingView(string userInput)
    {
        //Replaced this line with code from Listing 8-12
        var filter = $"%{userInput}%";
        var items = await _db.ItemDetailSummaries
                                .Where(x => EF.Functions.Like(x.ItemName ?? "", filter)
                                            || EF.Functions.Like(x.Contributors ?? "", filter))
                                .ToListAsync();
        return items;
    }

    private async Task FilterItemsByUserInputUsingViewAndPaging(string userInput)
    {
        int pageSize = 10; //you could make this a parameter
        int currentPage = 1;
        bool keepGoing = true;
        var filter = $"%{userInput}%";
        while (keepGoing)
        {
            //Replaced these four lines of code with the code from Listing 8-14
            var pageResults = await _db.ItemDetailSummaries
                    .Where(x => EF.Functions.Like(x.ItemName ?? "", filter)
                                || EF.Functions.Like(x.Contributors ?? "", filter))
                    .OrderBy(i => i.ItemName)
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();


            if (!pageResults.Any())
            {
                Console.WriteLine("No more results.");
                break;
            }

            Console.WriteLine($"\nPage {currentPage}:");

            var output = ConsolePrinter.PrintBoxedList(pageResults, x => $"ID: {x.ItemId}] Name: {x.ItemName}| Contributors: {x.Contributors}", $"Viewing page {currentPage} results");
            Console.WriteLine(output);

            Console.Write("\nShow next page? (y/n): ");
            var key = Console.ReadLine();
            if (key?.ToLower() != "y")
            {
                keepGoing = false;
            }
            else
            {
                currentPage++;
            }
        }
    }

    private async Task RunAsNoTrackingDemo()
    {
        //Get the record from the database (note, if the item is not found, find one to match in your data):
        string name = "The Lord of the Rings: The Fellowship of the Ring";
        /******************** do not change above this line (Unless no match) ***************/


        //Listing 8-16 is placed here:
        var itemDetail = await _db.Items.FirstOrDefaultAsync(x => x.Name == name);


        /******************** do not change below this line***************/
        if (itemDetail is null)
        {
            throw new Exception("Item was not found");
        }
        Console.WriteLine(ConsolePrinter.PrintFormattedMessage($"The Item: {itemDetail.Name} with notes: {itemDetail?.Notes}", "Item Detail"));

        //prove that it is connected:
        itemDetail.Notes = "The Notes can be updated when the item is connected";
        await _db.SaveChangesAsync();

        //get the item detail
        /******************** do not change above this line ***************/


        // Listing 8-17 goes here:
        var itemDetailUpdated = await _db.Items
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Name == name);


        /******************** do not change below this line***************/
        if (itemDetailUpdated is null)
        {
            throw new Exception("Item was not found");
        }
        Console.WriteLine(ConsolePrinter.PrintFormattedMessage($"The Item: {itemDetailUpdated.Name} with notes: {itemDetailUpdated?.Notes}", "Item Detail Updated"));

        //attempt to update on disconnected data
        itemDetailUpdated.Notes = "Disconnected objects can't affect the backing data store";
        await _db.SaveChangesAsync();

        //prove that it is not affected:
        var itemDetailFinal = await _db.Items
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Name == name);

        if (itemDetailFinal is null)
        {
            throw new Exception("Item was not found");
        }
        Console.WriteLine(ConsolePrinter.PrintFormattedMessage($"The Item: {itemDetailFinal.Name} with notes: {itemDetailFinal?.Notes}", "Item Detail Final"));

        WaitForUserResponse();
    }

    private List<string> GetMenuOptions()
    {
        return new List<string>
        {
            "Items To List, then Order, then Take",
            "Items Ordered, then To List, then Take",
            "Filter and Match for Item or Contributor Name",
            "Filter and Match using the View",
            "Filter/Match and Page Results",
            "Disconnected Queries [AsNoTracking]",
            "Back to Main Menu"
        };
    }
}
