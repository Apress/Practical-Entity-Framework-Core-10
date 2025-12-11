using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels;
using EF10_InventoryServiceLayer;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.CRUD;

public class DeleteOperationsMenu
{
    private readonly int _lineLength;
    private readonly IItemService _itemService;
    private readonly ICategoryService _categoryService;
    public DeleteOperationsMenu(int lineLength, IItemService itemService, ICategoryService categoryService)
    {
        _lineLength = lineLength;
        _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
        _categoryService = categoryService;
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
                        string itemName = "Blade Runner 2049 - The Final Cut";

                        //ENSURE item exists before attempting to delete it
                        var existingItem = await _itemService.GetItemByNameWithGenreAsync(itemName);
                        if (existingItem == null)
                        {
                            //Item does not exist, so create it
                            var newItem = new Item
                            {
                                Name = itemName,
                                Description = "A sequel to the original Blade Runner movie.",
                                Notes = "This is the final cut edition.",
                                Quantity = 1,
                                IsOnSale = false,
                                PurchasedDate = DateTime.Now.AddMonths(-2),
                                SoldDate = null,
                                PurchasePrice = 19.99M,
                                CurrentValue = 15.00M,
                            };
                            await _itemService.AddItemAsync(newItem);
                        }

                        //Remove Blade Runner 2049 by name
                        success = await RemoveItemByName(itemName);
                        if (success)
                        {
                            var bladeRunnerItem = await _itemService.GetItemByNameWithGenreAsync(itemName);
                            if (bladeRunnerItem != null)
                            {
                                throw new Exception($"Item still exists: {bladeRunnerItem.Name} (ID: {bladeRunnerItem.Id})");
                            }
                            Console.WriteLine($"Item '{itemName}' removed successfully.");
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
                        string itemName = "Common Green Darner";

                        //ENSURE item exists before attempting to delete it
                        var existingItem = await _itemService.GetItemByNameWithGenreAsync(itemName);
                        if (existingItem == null)
                        {
                            //Item does not exist, so create it
                            var category = await _categoryService.GetCategoryByNameAsync("Insect");
                            if (category == null)
                            {
                                //category does not exist, so create it
                                category = new Category { CategoryName = "Insect" };
                                await _categoryService.AddCategoryAsync(category);
                            }
                            var newItem = new Item
                            {
                                Name = itemName,
                                Description = "A dragonfly",
                                Category = category,
                            };
                            await _itemService.AddItemAsync(newItem);
                        }

                        var itemToRemove = await _itemService.GetItemByNameWithGenreAsync(itemName);
                        if (itemToRemove == null)
                        {
                            throw new Exception($"Item '{itemName}' should exist but was not found.");
                        }

                        success = await RemoveItemById(itemToRemove.Id);
                        if (success)
                        {
                            Console.WriteLine($"Item '{itemName}' removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to remove item '{itemName}'.");
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

    //listing 6-26
    public async Task<bool> RemoveItemByName(string itemName)
    {
        if (string.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException("Item name cannot be null or empty.", nameof(itemName));
        }
        var item = await _itemService.GetItemByNameWithGenreAsync(itemName);
        if (item == null)
        {
            Console.WriteLine($"Item '{itemName}' not found.");
            return false; //indicate failure
        }
        return await RemoveItem(item);
    }

    private async Task<bool> RemoveItem(Item item)
    {
        return await _itemService.DeleteItemAsync(item.Id) != null;
    }

    // Listing 6-28 
    private async Task<bool> RemoveItemById(int itemId)
    {
        var item = await _itemService.GetItemByIdAsync(itemId);
        if (item == null)
        {
            Console.WriteLine($"Item with ID '{itemId}' not found.");
            return false; //indicate failure
        }
        return await RemoveItem(item);
    }
}
