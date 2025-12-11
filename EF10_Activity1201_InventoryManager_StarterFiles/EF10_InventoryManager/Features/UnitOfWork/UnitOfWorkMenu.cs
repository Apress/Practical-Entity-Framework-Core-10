using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryServiceLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryManager.Features.UnitOfWork;

public class UnitOfWorkMenu
{
    private readonly int _lineLength;
    private readonly IItemService _itemService;
    private readonly ICategoryService _categoryService;
    private readonly IContributorService _contributorService;
    private readonly IGenreService _genreService;
    private readonly IParserService _parserService;

    public UnitOfWorkMenu(int lineLength, IItemService itemService, ICategoryService categoryService,
                          IContributorService contributorService, IGenreService genreService,
                            IParserService parserService)
    {
        _lineLength = lineLength;
        _itemService = itemService;
        _categoryService = categoryService;
        _contributorService = contributorService;
        _genreService = genreService;
        _parserService = parserService;
    }

    public async Task ShowAsync()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();

            var menuOptions = GetMenuOptions();
            var menuText = MenuGenerator.GenerateMenu(
                                "Unit Of Work",
                                "Select a UoW operation:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Loading Data With Bad Input [file 1] ...");
                        var file1 = "DataFiles/ItemDataBad.dat";
                        var success = await ProcessBulkLoad(file1);
                        if (success)
                        {
                            Console.WriteLine("Data loaded successfully.");
                            await ShowItems();
                        }
                        else
                        {
                            Console.WriteLine("Failed to load data.");
                        }
                        WaitForUserFeedback();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Loading Data With Bad Input [file 2] ...");
                        var file2 = "DataFiles/ItemDataBad2.dat";
                        var success = await ProcessBulkLoad(file2);
                        if (success)
                        {
                            Console.WriteLine("Data loaded successfully.");
                            await ShowItems();
                        }
                        else
                        {
                            Console.WriteLine("Failed to load data.");
                        }
                        WaitForUserFeedback();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Loading Data With Good Input ...");
                        var file3 = "DataFiles/ItemDataGood.dat";
                        var success = await ProcessBulkLoad(file3);
                        if (success)
                        {
                            Console.WriteLine("Data loaded successfully.");
                            await ShowItems();
                        }
                        else
                        {
                            Console.WriteLine("Failed to load data.");
                        }

                        WaitForUserFeedback();
                        break;
                    }
                case 4:
                default:
                    back = true;
                    break;
            }
            ;
        }
    }

    private static List<string> GetMenuOptions()
    {
        return new List<string>
                {
                    "Load Bad Data File 1",
                    "Load Bad Data File 2",
                    "Load Good Data File",
                    "Back to Main Menu"
                };
    }

    private void WaitForUserFeedback()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private async Task<bool> ProcessBulkLoad(string filePath)
    {
        try
        {
            var parsedItems = _parserService.ParseFromFile(filePath);
            if (parsedItems.Count == 0)
            {
                Console.WriteLine("No valid items found in the file.");
                return false;
            }

            return await _itemService.BulkLoadItemDataAsync(parsedItems);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file: {ex.Message}");
            return false;
        }
    }

    private async Task ShowItems()
    {
        var items = await _itemService.GetAllItemsAsync();
        if (items == null || items.Count == 0)
        {
            Console.WriteLine("No items found in the inventory.");
            return;
        }
        Console.WriteLine(ConsolePrinter.PrintBoxedList(items, x => $"Item: {x.Name} | Qty: {x.Quantity}", "Items"));
    }
}

