using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.SortingFilteringPaging;

public class DemoQueriesMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    public DemoQueriesMenu(InventoryDbContext context, int lineLength)
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
                                "Demo Queries",
                                "Select a Query to Execute:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    await LazyLoading();
                    break;
                case 2:
                    await EagerLoading();
                    break;
                case 3:
                    await QueryThenSortThenDisplay();
                    break;
                case 4:
                    await QueryWithSortThenDisplay();
                    break;
                case 5:
                    await GetItemsNoTracking();
                    break;
                case 6:
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }


    private async Task LazyLoading()
    {
        //Listing 8-1
        //Use this query in conjunction with the DbContext configuration in Program.cs to enable lazy loading
        //Note: Lazy loading is disabled by default in EF Core 6 and later, but you can enable it if needed.
        //After running this method, disable lazy loading proxies if you turned them on.
        //In other words, don't forget to modify program.cs to uncomment the UseLazyLoadingProxies() call
        Console.WriteLine("Lazy Loading Example:");
        var items = _db.Items.ToList();
        foreach (var item in items)
        {
            Console.WriteLine($"Item {item.Name} has category " +
                    $"{item.Category?.CategoryName ?? "Item Category is null"}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task EagerLoading()
    {
        //Listing 8-2
        //In other words, don't forget to modify program.cs to comment out the UseLazyLoadingProxies() call
        Console.WriteLine("Eager Loading Example:");
        var items = _db.Items.Include(i => i.Category).ToList();
        foreach (var item in items)
        {
            Console.WriteLine($"Item {item.Name} has category " +
                                $"{item.Category.CategoryName}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task QueryThenSortThenDisplay()
    {
        //Listing 8-3
        Console.WriteLine("Getting items to a list, then sorting");

        var items = await _db.Items.ToListAsync();
        items = items.OrderByDescending(x => x.Name).ToList(); //requires another call to ToList() to make the sort happen
        foreach (var item in items)
        {
            Console.WriteLine($"Item {item.Name}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task QueryWithSortThenDisplay()
    {
        //Listing 8-4
        Console.WriteLine("Getting items sorted, then to List");
        var items = await _db.Items.OrderByDescending(x => x.Name).ToListAsync();
        foreach (var item in items)
        {
            Console.WriteLine($"Item {item.Name}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task GetItemsNoTracking()
    {
        //Listing 8-5
        Console.WriteLine("Getting items sorted, then to List");
        var items = await _db.Items
                                .OrderByDescending(x => x.Name)
                                .AsNoTracking()
                                .ToListAsync();
        foreach (var item in items)
        {
            Console.WriteLine($"Item {item.Name}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private List<string> GetMenuOptions()
    {
        return new List<string>
        {
            "Lazy Loading",
            "Eager Loading",
            "Query then Sort then display",
            "Query with Sort then display",
            "Get Items No Tracking",
            "Back to Main Menu"
        };
    }
}
