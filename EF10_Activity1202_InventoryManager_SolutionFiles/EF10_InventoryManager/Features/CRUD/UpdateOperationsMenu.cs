using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels;
using EF10_InventoryServiceLayer;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager.Features.CRUD;

public class UpdateOperationsMenu
{
    private readonly int _lineLength;
    private readonly IItemService _itemsService;
    private readonly IGenreService _genreService;
    private readonly ICategoryService _categoryService;

    public UpdateOperationsMenu(int lineLength, IItemService itemsService, IGenreService genreService, ICategoryService categoryService)
    {
        _lineLength = lineLength;
        _itemsService = itemsService;
        _genreService = genreService;
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
                                "Update Operations",
                                "Select an update operation:"
                                , menuOptions
                                , _lineLength
                            );

            int choice = UserInput.GetInputFromUser(menuText, shouldConfirm: true, min: 1, max: menuOptions.Count);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Updating genre (bad demo)...");
                    success = await UpdateGenreBadDemo();
                    if (!success)
                    {
                        Console.WriteLine("Failed to update genre as expected.");
                    }
                    else
                    {
                        Console.WriteLine("Unexpected success in updating genre.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    //ensure genre sci-fi exists before updating
                    var addedGenre = new Genre { GenreName = "Sci-Fi", IsActive = true };
                    var existingGenre = await _genreService.GetGenreByNameAsync(addedGenre.GenreName); //updated to use service layer for 11-1
                    if (existingGenre == null)
                    {
                        await _genreService.AddGenreAsync(addedGenre); //updated to use service layer for 11-1
                    }

                    var updateSuccess = await UpdateGenreChangeNameImplicitUpdateDemo("Sci-Fi", "Post-Apocalyptic");
                    if (updateSuccess)
                    {
                        var theGenre = await _genreService.GetGenreByNameAsync("Post-Apocalyptic");  //updated to use service layer for 11-1
                        Console.WriteLine("Genre updated Successfully:");
                        Console.WriteLine($"Genre details: {theGenre?.GenreName}");
                    }
                    else
                    {
                        Console.WriteLine("Failed to update genre name.");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
                    await CreateAMovieWithGenre();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("Updating item and genre names...");
                    // Update item and genre names
                    // Assuming the original item name is "Blade Runner 2049" and the genre is "Dystopian"
                    // and we want to change it to "Blade Runner 2049 - The Final Cut" and "Robotic Dystopia"
                    string newItemName = "Blade Runner 2049 - The Final Cut";
                    string originalItemName = "Blade Runner 2049";
                    string originalGenreName = "Dystopian";
                    string newGenreName = "Robotic Dystopia";
                    success = await UpdateItemAndGenreNamesAsync(originalItemName, newItemName,
                                                        originalGenreName, newGenreName);
                    if (success)
                    {
                        var updatedItem = await _itemsService.GetItemByNameWithGenreAsync(newItemName); //updated to use service layer for 11-1

                        if (updatedItem != null)
                        {
                            Console.WriteLine($"Updated Item: {updatedItem.Name}");
                            if (updatedItem.Genres != null && updatedItem.Genres.Any())
                            {
                                foreach (var genre in updatedItem.Genres)
                                {
                                    Console.WriteLine($"Genre: {genre.GenreName}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No genres associated with the updated item.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Item not found after update.");
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 5:
                    success = await UpdateMultipleItemsOnSale();
                    if (success)
                    {
                        var itemsOnSale = _itemsService.FindItemsAsync(i => i.IsOnSale).Result; //updated to use service layer for 11-1
                        if (itemsOnSale.Any())
                        {
                            Console.WriteLine("Items on sale:");
                            foreach (var item in itemsOnSale)
                            {
                                Console.WriteLine($"- {item.Name} (ID: {item.Id})");
                            }
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 6:
                    back = true;
                    break;
            }
        }
    }

    private static List<string> GetMenuOptions()
    {
        return new List<string>
                {
                    "Update Genre (Bad Demo)",
                    "Update Genre Change Name (Implicit Update)",
                    "Create a Movie with Genre",
                    "Update Item and Genre Names",
                    "Update Multiple Items On Sale",
                    "Back to Main Menu"
                };
    }

    //listing 6-17 
    public async Task<bool> UpdateGenreBadDemo()
    {
        //the data was seeded, so it is guaranteed to exist, but no key is leveraged:
        var genre = new Genre { GenreName = "Science Fiction" };
        //attempt to update the genre name only
        genre.GenreName = "Sci-Fi";
        try
        {
            //changed to use service layer for 11-1, no such thing as a bad update anymore...
            //so have to just tweak the logic
            var existingGenre = await _genreService.GetGenreByNameAsync(genre.GenreName); //updated to use service layer for 11-1

            if (existingGenre == null)
            {
                Console.WriteLine("Genre not found, nothing to update...");
                return false; //indicate failure
            }

            genre.Id = existingGenre.Id; //set the ID to the existing genre's ID
            await _genreService.UpdateGenreAsync(genre); //updated to use service layer for 11-1
            return true;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine($"Concurrency error: {ex.Message}");
            return false; //indicate failure
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating genre: {ex.Message}");
            return false; //indicate failure
        }
    }

    /* Listing 6-19 */
    private async Task<bool> UpdateGenreChangeNameImplicitUpdateDemo(string genreName, string newGenreName)
    {
        var genre = await _genreService.GetGenreByNameAsync(genreName); //updated to use service layer for 11-1
        if (genre == null)
        {
            Console.WriteLine("Genre not found.");
            return false; //indicate failure
        }
        genre.GenreName = newGenreName; //change the name
        var genreResult = await _genreService.UpdateGenreAsync(genre); //updated to use service layer for 11-1
        return genreResult.GenreName == newGenreName && genreResult.Id == genre.Id;
    }

    //do not modify this method
    private async Task<bool> CreateAMovieWithGenre()
    {
        Console.WriteLine(new string('*', 60));
        Console.WriteLine("Creating a new movie with genre...");

        //var existingItem = await _db.Items
        //    .Where(i => i.Name == "Blade Runner 2049")
        //    .SingleOrDefaultAsync();
        var existingItem = await _itemsService.GetItemByNameWithGenreAsync("Blade Runner 2049"); //updated to use service layer for 11-1
        if (existingItem != null)
        {
            Console.WriteLine($"Movie 'Blade Runner 2049' already exists with ID: {existingItem.Id}");
            return true; // Exit if the movie already exists
        }

        // Create a new genre and category if they don't exist
        var genres = await _genreService.GetAllGenresAsync(); //updated to use service layer for 11-1
        var categories = await _categoryService.GetAllCategoriesAsync(); //updated to use service layer for 11-1
        var movieCategory = categories.FirstOrDefault(c => c.CategoryName == "Movie") ??
                            new Category { CategoryName = "Movie", Description = "A category for movies." };
        var genreSciFi = genres.FirstOrDefault(g => g.GenreName == "Science Fiction") ??
                            new Genre { GenreName = "Science Fiction", IsActive = true };
        // Create a new genre for Dystopian (should not exist)
        var genreDystopian = genres.FirstOrDefault(g => g.GenreName == "Dystopian") ??
                            new Genre { GenreName = "Dystopian", IsActive = true };
        // Create a new movie item associated with the category and genres
        var movie = new Item
        {
            Name = "Blade Runner 2049",
            Description = "A sequel to the original Blade Runner.",
            CategoryId = movieCategory.Id,
            Category = movieCategory, // Associate the category
            IsActive = true,
            IsOnSale = false,
            Genres = new List<Genre> { genreSciFi, genreDystopian }, // Associate the genres
            CreatedByUserId = Guid.NewGuid().ToString(),
            CreatedDate = DateTime.UtcNow,
        };

        var movieResult = await _itemsService.AddItemAsync(movie); //updated to use service layer for 11-1

        Console.WriteLine($"Blade runner 2049 created with ID: {movieResult.Id}");
        Console.WriteLine(new string('*', 60));
        return true; // Indicate success
    }

    //listing 6-22
    private async Task<bool> UpdateItemAndGenreNamesAsync(
        string originalItemName, string newItemName,
        string originalGenreName, string newGenreName)
    {
        var itemDetail = await _itemsService.GetItemByNameWithGenreByNameAsync(originalItemName, originalGenreName);
        if (itemDetail == null)
        {
            Console.WriteLine("Item or Item with Genre not found.");
            return false; //indicate failure
        }
        itemDetail.Name = newItemName;
        var genre = itemDetail.Genres?.FirstOrDefault(g => g.GenreName == originalGenreName);
        if (genre != null)
        {
            genre.GenreName = newGenreName;
        }

        var itemUpdateResult = await _itemsService.UpdateItemAsync(itemDetail); //updated to use service layer for 11-1
        if (itemUpdateResult == null || itemUpdateResult.Name != newItemName || itemUpdateResult.Id != itemDetail.Id)
        {
            Console.WriteLine("Failed to update item name.");
            return false; //indicate failure
        }
        return itemUpdateResult.Genres?.FirstOrDefault(g => g.GenreName == newGenreName) != null;
    }


    //listing 6-24
    private async Task<bool> UpdateMultipleItemsOnSale()
    {
        var items = await _itemsService.GetAllItemsAsync(); //updated to use service layer for 11-1
        if (!items.Any())
        {
            Console.WriteLine("No items to update.");
            return false; //indicate failure
        }
        foreach (var item in items)
        {
            item.IsOnSale = true; //set all items to on sale
        }
        var result = await _itemsService.UpdateRangeAsync(items); //updated to use service layer for 11-1
        return result == items.Count; //return true if all items were updated
    }
}