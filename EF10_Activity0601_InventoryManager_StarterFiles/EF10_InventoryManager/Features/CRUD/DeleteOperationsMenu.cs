using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.CRUD;

public class DeleteOperationsMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    public DeleteOperationsMenu(InventoryDbContext context, int lineLength)
    {
        _db = context;
        _lineLength = lineLength;
    }

    public async Task ShowAsync()
    {
        bool back = false;
        bool success = false;
        while (!back)
        {
            Console.Clear();

            var menuOptions = GetMenuOptions();

            var menuText = MenuGenerator.GenerateMenu(
                                "Delete Operations",
                                "Select a delete operation:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    {
                        //Remove Blade Runner 2049 by name
                        string itemName = "Blade Runner 2049 - The Final Cut";
                        success = await RemoveItemByName(itemName);
                        if (success)
                        {
                            var bladeRunnerItem = await _db.Items
                                                            .SingleOrDefaultAsync(i => i.Name
                                                                == "Blade Runner 2049 - The Final Cut");
                            if (bladeRunnerItem != null)
                            {
                                throw new Exception($"Item still exists: {bladeRunnerItem.Name} (ID: {bladeRunnerItem.Id})");
                            }
                            Console.WriteLine("Item 'Blade Runner 2049 - The Final Cut' removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to remove item '{itemName}'.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        var itemToRemove = _db.Items.SingleOrDefault(i => i.Name == "Common Green Darner");
                        success = await RemoveItemById(itemToRemove.Id);
                        if (success)
                        {
                            Console.WriteLine("Item 'Common Green Darner' removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to remove item 'Common Green Darner'.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        back = true;
                        break;
                    }
            }
        }
    }

    private List<string> GetMenuOptions()
    {
        return new List<string>
                {
                    "Remove Item by Name",
                    "Remove Item by ID",
                    "Back to Main Menu"
                };
    }


    public async Task<bool> RemoveItemByName(string itemName)
    {
        //TODO: Use the code from listing 6-26 to complete this method.
        throw new NotImplementedException("RemoveItemByName method is not implemented yet.");
    }

    //DO NOT Modify this code
    private async Task<bool> RemoveItem(Item item)
    {
        _db.Items.Remove(item);
        var result = await _db.SaveChangesAsync();
        return result == 1; //return true if one row was deleted
    }

    private async Task<bool> RemoveItemById(int itemId)
    {
        /* TODO: Use the code in Listing 6-28 to complete this method*/
        throw new NotImplementedException();
    }
}
