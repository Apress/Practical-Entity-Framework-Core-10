using EF10_NewFeatureDemos.NewFeatureDemos;
using EF10_NewFeaturesDbLibrary;

namespace EF10_NewFeatureDemos.ConsoleHelpers;

public class MainMenu
{
    private readonly InventoryDbContext _db;
    private readonly ShowDataDemo _showDataDemo;
    private readonly BulkDeleteDemo _bulkDeleteDemo;
    private readonly BulkUpdateDemo _bulkUpdateDemo;
    private readonly JsonColumnsDemo _jsonColumnsDemo;
    private readonly TpcDemo _tpcDemo;
    private readonly RawSqlToDtoDemo _rawSqlToDtoDemo;
    private readonly InterceptorsAndLoggingDemo _interceptorsAndLoggingDemo;
    private readonly NamedQueryFiltersDemo _namedQueryFiltersDemo;
    private readonly DefaultConstraintsDemo _defaultConstraintsDemo;
    private readonly LinqEnhancementsDemo _linqEnhancementsDemo;

    public MainMenu(InventoryDbContext context)
    {
        _db = context;
        _showDataDemo = new ShowDataDemo(_db);
        _bulkUpdateDemo = new BulkUpdateDemo(_db);
        _bulkDeleteDemo = new BulkDeleteDemo(_db);
        _jsonColumnsDemo = new JsonColumnsDemo(_db);
        _tpcDemo = new TpcDemo(_db);
        _rawSqlToDtoDemo = new RawSqlToDtoDemo(_db);
        _interceptorsAndLoggingDemo = new InterceptorsAndLoggingDemo(_db);
        _namedQueryFiltersDemo = new NamedQueryFiltersDemo(_db);
        _defaultConstraintsDemo = new DefaultConstraintsDemo(_db);
        _linqEnhancementsDemo = new LinqEnhancementsDemo(_db);
    }

    public async Task ShowAsync()
    {
        bool shouldContinue = true;
        while (shouldContinue)
        {
            Console.Clear();

            List<string> menuOptions = GetMenuOptions();

            var menuText = MenuGenerator.GenerateMenu("Main Menu", "Please select an operation", menuOptions, 40);

            // Show menu and get user choice
            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            try
            {
                shouldContinue = await HandleMenuChoiceAsync(choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private async Task<bool> HandleMenuChoiceAsync(int choice)
    {
        IAsyncDemo demo = _bulkUpdateDemo;
        switch (choice)
        {
            case 1:
                demo = _showDataDemo;
                break;
            case 2:
                demo = _interceptorsAndLoggingDemo;
                break;
            case 3:
                demo = _namedQueryFiltersDemo;
                break;
            case 4:
                demo = _bulkUpdateDemo;
                break;
            case 5:
                demo = _bulkDeleteDemo;
                break;
            case 6:
                demo = _jsonColumnsDemo;
                break;
            case 7:
                demo = _rawSqlToDtoDemo;
                break;
            case 8:
                demo = _defaultConstraintsDemo;
                break;
            case 9:
                demo = _linqEnhancementsDemo;
                break;
            case 10:
                demo = _tpcDemo;
                break;
            default:
                return false;
        }

        await demo.RunAsync();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return true;
    }

    private List<string> GetMenuOptions()
    {
        return new List<string> {
            "Show the Data",
            "Interceptors and Logging",
            "Named Query Filters",
            "Bulk Update",
            "Bulk Delete",
            "Work with JSON Columns",
            "Raw SQL Projection to DTOs",
            "Default Constraints",
            "Linq Enhancements",
            "Fully Supported Inheritance (TPC)",
            "Exit"
        };
    }

}
