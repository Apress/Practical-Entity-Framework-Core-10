using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.CRUD;

public class ReadOperationsMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    public ReadOperationsMenu(InventoryDbContext context, int lineLength)
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
                                "Read Operations",
                                "Select a read operation:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    {
                        //Get All Items
                        var items = await GetAllItemsAsync_NoInclude();

                        Console.WriteLine(ConsolePrinter.PrintBoxedList(items, x => $"Item: {x.Name} | Qty: {x.Quantity}", "Items"));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        //find categories by ID [1, 2, 100 ==> 1 & 2 good, 100 bad]
                        var category1 = await GetCategoryById_Find(1);
                        var category2 = await GetCategoryById_Find(2);
                        var category100 = await GetCategoryById_Find(100);
                        List<string> categories = new List<string>
                    {
                        $"Category 1: {category1?.CategoryName ?? "Not Found"}",
                        $"Category 2: {category2?.CategoryName ?? "Not Found"}",
                        $"Category 100: {category100?.CategoryName ?? "Not Found"}",
                    };
                        Console.WriteLine(ConsolePrinter.PrintBoxedList(categories, c => c, "Categories", _lineLength));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        //find categories by ID [1, 2, 100 ==> 1 & 2 good, 100 bad]
                        var category1 = await GetCategoryById_SingleOrDefault(1);
                        var category2 = await GetCategoryById_SingleOrDefault(2);
                        var category100 = await GetCategoryById_SingleOrDefault(100);
                        List<string> categories = new List<string>
                    {
                        $"Category 1: {category1?.CategoryName ?? "Not Found"}",
                        $"Category 2: {category2?.CategoryName ?? "Not Found"}",
                        $"Category 100: {category100?.CategoryName ?? "Not Found"}",
                    };
                        Console.WriteLine(ConsolePrinter.PrintBoxedList(categories, c => c, "Categories", _lineLength));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Searching for items with a specific filter...");
                        string filter = UserInput.GetInputFromUser("Enter a filter string (or leave empty for no filter):", shouldConfirm: true);
                        var filteredItems = await GetAllItemsByFilterAsyncEnumerable(filter);
                        Console.WriteLine(new string('-', 60));
                        if (filteredItems.Any())
                        {
                            Console.WriteLine(ConsolePrinter.PrintBoxedList(filteredItems, x => $"Item: {x.Name}", "Filtered Items"));
                        }
                        else
                        {
                            Console.WriteLine($"No items found with '{filter}' in their name.");
                        }
                        Console.WriteLine(new string('*', 60));

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Searching for items with a specific filter...");
                        string filter = UserInput.GetInputFromUser("Enter a filter string (or leave empty for no filter):", shouldConfirm: true);
                        var filteredItems = await GetAllItemsByFilterAsync_LINQ(filter);

                        if (filteredItems.Any())
                        {
                            Console.WriteLine(ConsolePrinter.PrintBoxedList(filteredItems, x => $"Item: {x.Name}", "Filtered Items"));
                        }
                        else
                        {
                            Console.WriteLine($"No items found with '{filter}' in their name.");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 6:
                    {
                        //Get All Items without any included relational data.
                        //This method is set from the start, no changes here
                        var items = await GetAllItemsAsync_NoInclude();

                        Console.WriteLine(ConsolePrinter.PrintBoxedList(items, x => $"Item: {x.Name} has Category: {x.Category?.CategoryName ?? "No Category"}"
                                                                            , "Items (No Include Category)", _lineLength));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 7:
                    {
                        var items = await GetAllItemsAsync_IncludeCategory();
                        Console.WriteLine(ConsolePrinter.PrintBoxedList(items, x => $"Item: {x.Name} has Category: {x.Category?.CategoryName ?? "No Category"}"
                                                                            , "Items (Include Category)", _lineLength));
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 8:
                    {
                        string contributorName = UserInput.GetInputFromUser("Enter Contributor Name to search for their items:", shouldConfirm: true);
                        var contributor = await GetContributorDataByName(contributorName);

                        if (contributor != null)
                        {
                            Console.WriteLine($"Contributor: {contributor.ContributorName}");
                            if (contributor.ItemContributors.Any())
                            {
                                Console.WriteLine("Items contributed:");
                                foreach (var itemContributor in contributor.ItemContributors)
                                {
                                    Console.WriteLine($"- {itemContributor.Item.Name}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No items contributed by this contributor.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No items found for contributor '{contributorName}'.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 9:
                default:
                    {
                        back = true;
                        break;
                    }
            }
        }
    }

    private static List<string> GetMenuOptions()
    {
        return new List<string>
                {
                    "Get All Items",
                    "Get Category by ID (Find)",
                    "Get Category by ID (SingleOrDefault)",
                    "Get All Items by Filter (AsyncEnumerable)",
                    "Get All Items by Filter (LINQ)",
                    "Get All Items (No Include Category)",
                    "Get All Items (Include Category)",
                    "Get Items by Contributor Name",
                    "Back to Main Menu"
                };
    }

    // Code for Read Operations
    private async Task<List<Item>> GetAllItemsAsync_NoInclude()
    {
        //This code is set from the start, no changes here
        return await _db.Items.OrderBy(x => x.Name).ToListAsync();
    }

    private async Task<Category> GetCategoryById_Find(int id)
    {
        /* Updated with code from Listing 6-3 */
        return await _db.Categories.FindAsync(id);
    }

    private async Task<Category> GetCategoryById_SingleOrDefault(int id)
    {
        /* Updated with code from Listing 6-4  */
        return await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
    }

    private async Task<List<Item>> GetAllItemsByFilterAsyncEnumerable(string filter)
    {
        /* Updated with code from Listing 6-5 */
        var query = _db.Items.AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter))
        {
            query = query.Where(x => x.Name.Contains(filter));
        }
        var enumerator = query
            .AsAsyncEnumerable()
            .GetAsyncEnumerator();
        var items = new List<Item>();
        try
        {
            while (await enumerator.MoveNextAsync())
            {
                items.Add(enumerator.Current);
            }
        }
        finally
        {
            await enumerator.DisposeAsync();
        }
        return items;
    }


    private async Task<List<Item>> GetAllItemsByFilterAsync_LINQ(string filter)
    {
        //Updated with code from Listing 6-6
        return await _db.Items
                .Where(x => string.IsNullOrWhiteSpace(filter)
                            || x.Name.Contains(filter))
                .OrderBy(x => x.Name)
                .ToListAsync();
    }

    private async Task<List<Item>> GetAllItemsAsync_IncludeCategory()
    {
        /* Updated with code from Listing 6-7 */
        return await _db.Items.Include(x => x.Category)
                        .ToListAsync();
    }

    private async Task<Contributor> GetContributorDataByName(string contributorName)
    {
        /* Updated with code from Listing 6-9 */
        return await _db.Contributors
                .Include(x => x.ItemContributors)
                   .ThenInclude(y => y.Item)
                    .Where(x => x.ContributorName == contributorName)
                    .SingleOrDefaultAsync();
    }
}
