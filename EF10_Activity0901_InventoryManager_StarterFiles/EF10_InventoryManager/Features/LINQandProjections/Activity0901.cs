using AutoMapper;
using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels.DTOs;

namespace EF10_InventoryManager.Features.LINQandProjections;

public class Activity0901
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;
    private readonly IMapper _mapper;
    private readonly int _pageSize; // Number of items per page

    public Activity0901(InventoryDbContext context, int lineLength, IMapper mapper)
        : this(context, lineLength, mapper, 10) // Default page size is 10
    {
    }

    public Activity0901(InventoryDbContext context, int lineLength, IMapper mapper, int pageSize)
    {
        _db = context;
        _lineLength = lineLength;
        _mapper = mapper;
        _pageSize = pageSize;
    }

    private List<string> GetMenuOptions()
    {
        return new List<string>
        {
            "Project to an Anonymous Class",
            "Project to a Known Type",
            "Using Automapper ProjectTo",
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
                                "Chapter Nine Activity",
                                "Select a Query to Execute:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    Console.WriteLine(ConsolePrinter.PrintFormattedMessage("Projecting to an Anonymous Class", "Anonymous Types", _lineLength));
                    await ProjectToAnAnonymousClass();
                    WaitForUserResponse();
                    break;
                case 2:
                    Console.WriteLine(ConsolePrinter.PrintFormattedMessage("Projecting to a Known Type", "Known Types", _lineLength));
                    await ProjectToAKnownType();
                    WaitForUserResponse();
                    break;
                case 3:
                    Console.WriteLine(ConsolePrinter.PrintFormattedMessage("Mapping Projected Results to a DTO", "DTO Mapping", _lineLength));
                    await UsingAutoMapperProjectTO();
                    WaitForUserResponse();
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

    private void WaitForUserResponse()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task ProjectToAnAnonymousClass()
    {
        //query with projection to an anonymous type:
        //Listing 9-4
        //TODO: Add the code, remove the throw new not implemented exception
        throw new NotImplementedException();

        /***************** Uncomment, but Do not alter below this line ******************/
        /*  TODO: Remove this comment block after implementing the projection code
        bool keepGoing = true;
        int currentPage = 1;
        var totalPages = multiGenreItems.Count / _pageSize + (multiGenreItems.Count % _pageSize > 0 ? 1 : 0);
        
        while (keepGoing)
        {
            Console.Clear();
            var pageResults = multiGenreItems.Skip((currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            if (!pageResults.Any())
            {
                Console.WriteLine("No more results.");
                break;
            }

            Console.WriteLine(ConsolePrinter.PrintFormattedMessage($"Page {currentPage} of {totalPages}"
                                                , "Items with Multiple Genres"
                                                , _lineLength));

            foreach (var item in pageResults)
            {
                Console.WriteLine(ConsolePrinter.PrintFormattedMessage(string.Join(", ", item.Genres)
                                        , $"Item ID: {item.Id} - {item.Name}"
                                        , _lineLength));
            }

            if (currentPage < totalPages)
            {
                Console.WriteLine("Press any key to see the next page...");
                keepGoing = true;
                currentPage++;
            }
            else
            {
                Console.WriteLine("End of results. Press any key to exit.");
                keepGoing = false;
            }
            Console.ReadKey();
        }
        */  //TODO: Remove this comment block after implementing the projection code
    }

    private async Task ProjectToAKnownType()
    {
        //Listing 9-5
        //TODO: Add the code, remove the throw new not implemented exception
        throw new NotImplementedException();
        var items = new List<ItemByCategoryDTO>(); //replace this code with the actual query

        /***************** Do not alter below this line ******************/
        PrintItemByCategoryDetails(items);
    }

    private async Task UsingAutoMapperProjectTO()
    {
        //Listing 9-8
        //TODO: Add the code, remove the throw new not implemented exception
        throw new NotImplementedException();
        var items = new List<ItemByCategoryDTO>(); //replace this code with the actual query

        /***************** Do not alter below this line ******************/
        PrintItemByCategoryDetails(items);
    }

    //**************** do not alter below this line ****************/
    private void PrintItemByCategoryDetails(List<ItemByCategoryDTO> items)
    {
        var totalPages = items.Count / _pageSize + (items.Count % _pageSize > 0 ? 1 : 0);
        bool keepGoing = true;
        int currentPage = 1;
        while (keepGoing)
        {
            Console.Clear();
            var pageResults = items.Skip((currentPage - 1) * _pageSize).Take(_pageSize).ToList();
            if (!pageResults.Any())
            {
                Console.WriteLine("No more results.");
                break;
            }
            Console.WriteLine(ConsolePrinter.PrintFormattedMessage($"Page {currentPage} of {totalPages}", "Item Details by Category", _lineLength));
            foreach (var item in pageResults)
            {
                Console.WriteLine($"{item.CategoryName}: {item.Name} ({item.Id})");
                Console.WriteLine(new string('-', _lineLength));
            }
            if (currentPage < totalPages)
            {
                Console.WriteLine("Press any key to see the next page...");
                keepGoing = true;
                currentPage++;
            }
            else
            {
                Console.WriteLine("End of results. Press any key to exit.");
                keepGoing = false;
            }
            Console.ReadKey();
        }
    }
}
