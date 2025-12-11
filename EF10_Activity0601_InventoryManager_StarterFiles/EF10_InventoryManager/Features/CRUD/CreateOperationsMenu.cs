using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.CRUD;

public class CreateOperationsMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    public CreateOperationsMenu(InventoryDbContext context, int lineLength)
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
                        Console.WriteLine("Searching for items with a specific filter...");
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
                            var allContributors = await _db.Contributors.ToListAsync();
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

    private async Task<Category> CreateCategoryAsync(string categoryName, string? description = null)
    {
        /* TODO: Use the code from Listing 6-10 to add a single Category */
        throw new NotImplementedException();
    }

    // //Modified for Listing 6-12
    // private async Task<Category> CreateCategoryAsync(string categoryName, string? description = null)
    // {
    //     var category = await CreateOrGetCategoryAsync(categoryName, description);

    //     if (category.Id > 0)
    //     {
    //         await _db.SaveChangesAsync();
    //     }

    //     return category;
    // }

    //[Listing 6-11, Do not change this method code]
    private async Task<Category> CreateOrGetCategoryAsync(string categoryName, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(categoryName))
        {
            throw new ArgumentException("Category name cannot be null or empty.", nameof(categoryName));
        }
        // Check if the category already exists
        var existingCategory = await _db.Categories
                .SingleOrDefaultAsync(c => c.CategoryName.ToLower() == categoryName.ToLower());
        if (existingCategory != null)
        {
            // return the existing category if it already exists
            Console.WriteLine($"Category '{categoryName}' already exists with ID: {existingCategory.Id}");
            return existingCategory;
        }
        // Create a new category if it does not exist
        var category = new Category { CategoryName = categoryName, Description = description };
        _db.Categories.Add(category);
        //not saving to the database yet
        return category;
    }

    //[Listing 6-13, Do not change this method code]
    //Get a single item by name, or create a new one if it does not exist
    //This method is used to create or get an item in the in-memory context tracking.
    //no changes are persisted in this method
    public async Task<Item> CreateOrGetItemAsync(string itemName, string itemDescription)
    {
        // Check if the item already exists (hydrate category)
        var existingItem = await _db.Items
                                    .Include(i => i.Category)
            .Where(x => x.Name.ToLower() == itemName.ToLower())
            .SingleOrDefaultAsync();
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
        };
        return newItem;
    }

    private async Task<Item> CreateItemAndCategoryAsync(string itemName, string itemDescription
            , string categoryName, string? categoryDescription = null)
    {
        /* TODO - Use the code from Listing 6-14 to complete this method*/
        throw new NotImplementedException();
    }


    private async Task<bool> CreateMultipleContributorsAsync(List<Contributor> contributors)
    {
        /* TODO - Use the code from Listing 6-17 to complete this method*/
        throw new NotImplementedException();
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
        var existingContributor = await _db.Contributors
            .Where(x => x.ContributorName.ToLower() == contributorName.ToLower())
            .SingleOrDefaultAsync();
        if (existingContributor != null)
        {
            Console.WriteLine($"Contributor '{existingContributor.ContributorName}' already exists with ID: {existingContributor.Id}");
            return true; // Contributor already exists
        }
        return false; // Contributor does not exist
    }
}

