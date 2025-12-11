using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels;
using EF10_InventoryServiceLayer;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.CRUD;

public class CreateOperationsMenu
{
    private readonly IItemService _itemService;
    private readonly ICategoryService _categoryService;
    private readonly IContributorService _contributorService;
    private readonly int _lineLength;

    public CreateOperationsMenu(int lineLength
                                    , IItemService itemService, ICategoryService categoryService
                                    , IContributorService contributorService)
    {
        _lineLength = lineLength;
        _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
        _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        _contributorService = contributorService ?? throw new ArgumentNullException(nameof(contributorService));
    }

    public async Task ShowAsync()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();

            var menuOptions = GetMenuOptions();
            var menuText = MenuGenerator.GenerateMenu(
                                "Create Operations",
                                "Select a create operation:",
                                menuOptions,
                                _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Creating a new Category...");
                        string categoryName = UserInput.GetInputFromUser("Enter a category name:", shouldConfirm: true);
                        string categoryDescription = UserInput.GetInputFromUser("Enter a category description (or leave empty for no description):", shouldConfirm: true);

                        var category = await CreateCategoryAsync(categoryName, categoryDescription);

                        Console.WriteLine($"Category with ID: {category.Id}, CategoryName: '{category.CategoryName}' and description: '{category.Description}' created successfully.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Creating an item with a category...");
                        string itemName = UserInput.GetInputFromUser("Enter item name:", shouldConfirm: true);
                        string itemDescription = UserInput.GetInputFromUser("Enter item description:", shouldConfirm: true);
                        string categoryName = UserInput.GetInputFromUser("Enter category name:", shouldConfirm: true);
                        string categoryDescription = UserInput.GetInputFromUser("Enter category description (or leave empty for no description):", shouldConfirm: true);

                        var item = await CreateItemAndCategoryAsync(itemName, itemDescription, categoryName, categoryDescription);
                        Console.WriteLine($"Item with ID: {item.Id}, Name: '{item.Name}' " +
                                            $"and category {item.Category?.Id}: '{item.Category?.CategoryName}' created successfully.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Creating multiple contributors...");
                        var contributors = new List<Contributor>();
                        int numberOfContributors = UserInput.GetInputFromUser("How many contributors do you want to create?", shouldConfirm: true, min: 1);
                        for (int i = 0; i < numberOfContributors; i++)
                        {
                            string contributorName = UserInput.GetInputFromUser($"Enter name for contributor {i + 1}:", shouldConfirm: true);
                            contributors.Add(new Contributor { ContributorName = contributorName });
                        }
                        bool success = await CreateMultipleContributorsAsync(contributors);

                        if (success)
                        {
                            var allContributors = await _contributorService.GetAllContributorsAsync();
                            Console.WriteLine(ConsolePrinter.PrintBoxedList(
                                    allContributors,
                                    c => $"(ID: {c.Id}) - {c.ContributorName}",
                                    "List of Contributors"
                                ));
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                case 4:
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
                    "Create Category",
                    "Create Item and Category",
                    "Create Multiple Contributors",
                    "Back to Main Menu"
                };
    }

    //Modified for Listing 6-12
    private async Task<Category> CreateCategoryAsync(string categoryName, string? description = null)
    {
        var category = await CreateOrGetCategoryAsync(categoryName, description);

        if (category.Id == 0)
        {
            await _categoryService.AddCategoryAsync(category);
        }

        return category;
    }

    //[Listing 6-11, Do not change this method code]
    private async Task<Category> CreateOrGetCategoryAsync(string categoryName, string? description = null)
    {

        if (string.IsNullOrWhiteSpace(categoryName))
        {
            throw new ArgumentException("Category name cannot be null or empty.", nameof(categoryName));
        }
        // Check if the category already exists
        //moved to service call [Chapter 11, activity 11-1]
        var existingCategory = await _categoryService.GetCategoryByNameAsync(categoryName);

        if (existingCategory != null)
        {
            // return the existing category if it already exists
            Console.WriteLine($"Category '{categoryName}' already exists with ID: {existingCategory.Id}");
            return existingCategory;
        }

        // Create a new category if it does not exist
        var category = new Category { CategoryName = categoryName, Description = description };
        //note: with move to service layer, the AddCategoryAsync method will handle both adding and saving changes
        //      so there is no intermediate "tracking" of the category in memory going forward (changed for activity 11-1)
        return category;
    }

    //[Listing 6-13, Do not change this method code]
    //Get a single item by name, or create a new one if it does not exist
    //This method is used to create or get an item in the in-memory context tracking.
    //no changes are persisted in this method
    public async Task<Item> CreateOrGetItemAsync(string itemName, string itemDescription)
    {
        // Check if the item already exists (hydrate category)
        // utilize service code changed in Chapter 11, activity 11-1
        var existingItem = await _itemService.GetItemByNameWithCategoryAsync(itemName);
        if (existingItem != null)
        {
            Console.WriteLine($"Item '{existingItem.Name}' already exists with ID: {existingItem.Id}");
            return existingItem; // Return the existing item
        }
        // Create a new item if it doesn't exist
        var newItem = new Item
        {
            Name = itemName,
            Description = itemDescription,
            IsActive = true,
        };
        return newItem;
    }

    //Listing 6-14
    private async Task<Item> CreateItemAndCategoryAsync(string itemName, string itemDescription
            , string categoryName, string? categoryDescription = null)
    {
        // Create or get the category (not saving to the database yet)
        var category = await CreateOrGetCategoryAsync(categoryName, categoryDescription);

        // Create or get the item (not saving to the database yet)
        var item = await CreateOrGetItemAsync(itemName, itemDescription);

        if (item.Id > 0)
        {
            Console.WriteLine($"Item '{item.Name}' already exists with ID: {item.Id}");
            return item; // Return the existing item
        }

        // Associate the item with the category (note, not using the CategoryId property here)
        item.Category = category;

        // Add the item to the context, this will track the item in memory
        return await _itemService.AddItemAsync(item); // Using service method to add or update item
    }

    //Listing 6-17
    private async Task<bool> CreateMultipleContributorsAsync(List<Contributor> contributors)
    {
        if (contributors == null || !contributors.Any())
        {
            Console.WriteLine("No contributors to add.");
            return false;
        }

        var contributorsToAdd = new List<Contributor>();
        // Validate each contributor, and check if it already exists
        foreach (var contributor in contributors)
        {
            if (string.IsNullOrWhiteSpace(contributor.ContributorName))
            {
                Console.WriteLine("Contributor name cannot be null or empty.");
                continue;
            }
            // Check if the contributor already exists
            var exists = await CheckIfContributorExistsAsync(contributor.ContributorName);
            if (exists)
            {
                continue; // Skip adding this contributor
            }
            contributorsToAdd.Add(contributor);
        }
        // If no new contributors to add, return early
        if (!contributorsToAdd.Any())
        {
            Console.WriteLine("No new contributors to add.");
            return true; // No new contributors to add
        }

        // Add the contributors to the context
        //_db.Contributors.AddRange(contributorsToAdd);
        var result = await _contributorService.AddRangeAsync(contributorsToAdd); // Using service method to add contributors
        // Save changes to the database

        //counts should match
        Console.WriteLine($"{contributorsToAdd.Count} contributors added successfully.");

        return result == contributorsToAdd.Count;
    }

    //Helper method to check if a contributor already exists
    //DO NOT Change this method code
    private async Task<bool> CheckIfContributorExistsAsync(string contributorName)
    {
        if (string.IsNullOrWhiteSpace(contributorName))
        {
            Console.WriteLine("Contributor name cannot be null or empty.");
            return false;
        }

        // Check if the contributor already exists
        var existingContributor = await _contributorService.GetContributorByNameAsync(contributorName);
        if (existingContributor != null)
        {
            Console.WriteLine($"Contributor '{existingContributor.ContributorName}' already exists with ID: {existingContributor.Id}");
            return true; // Contributor already exists
        }
        return false; // Contributor does not exist
    }
}


