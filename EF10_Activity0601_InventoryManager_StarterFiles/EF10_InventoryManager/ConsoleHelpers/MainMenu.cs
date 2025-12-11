using EF10_InventoryDBLibrary;
using EF10_InventoryManager.Features.CRUD;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.ConsoleHelpers;

public class MainMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    private readonly CreateOperationsMenu _createOperationsMenu;
    private readonly DeleteOperationsMenu _deleteOperationsMenu;
    private readonly ReadOperationsMenu _readOperationsMenu;
    private readonly UpdateOperationsMenu _updateOperationsMenu;

    public MainMenu(InventoryDbContext context, int lineLength)
    {
        _db = context;
        _lineLength = lineLength;
        _createOperationsMenu = new CreateOperationsMenu(_db, _lineLength);
        _readOperationsMenu = new ReadOperationsMenu(_db, _lineLength);
        _updateOperationsMenu = new UpdateOperationsMenu(_db, _lineLength);
        _deleteOperationsMenu = new DeleteOperationsMenu(_db, _lineLength);
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
        switch (choice)
        {
            case 1:
                await _readOperationsMenu.ShowAsync();
                break;
            case 2:
                await _createOperationsMenu.ShowAsync();
                break;
            case 3:
                await _updateOperationsMenu.ShowAsync();
                break;
            case 4:
                await _deleteOperationsMenu.ShowAsync();
                break;
            case 5:
            default:
                return false;
        }
        return true;
    }

    private List<string> GetMenuOptions()
    {
        return new List<string> {
            "Read Operations",
            "Create Operations",
            "Update Operations",
            "Delete Operations",
            "Exit"
        };
    }
}
