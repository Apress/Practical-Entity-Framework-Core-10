using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryManager.Features.CRUD;

public class UpdateOperationsMenu
{
    private readonly InventoryDbContext _db;
    private readonly int _lineLength;

    public UpdateOperationsMenu(InventoryDbContext context, int lineLength)
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
                    var updateSuccess = await UpdateGenreChangeNameImplicitUpdateDemo("Sci-Fi", "Post-Apocalyptic");
                    if (updateSuccess)
                    {
                        var theGenre = await _db.Genres.SingleOrDefaultAsync(g => g.GenreName == "Post-Apocalyptic");
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
                        var updatedItem = await _db.Items
                            .Include(i => i.Genres)
                            .SingleOrDefaultAsync(i => i.Name == newItemName);

                        if (updatedItem != null)
                        {
                            Console.WriteLine($"Updated Item: {updatedItem.Name}");
                            foreach (var genre in updatedItem.Genres)
                            {
                                Console.WriteLine($"Genre: {genre.GenreName}");
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
                        var itemsOnSale = await _db.Items
                            .Where(i => i.IsOnSale)
                            .ToListAsync();
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


    public async Task<bool> UpdateGenreBadDemo()
    {
        // TODO: Use the code in listing 6-17 to complete this method.
        throw new NotImplementedException();
    }


    private async Task<bool> UpdateGenreChangeNameImplicitUpdateDemo(string genreName, string newGenreName)
    {
        /* TODO: Complete this method with the code in Listing 6-19 */
        throw new NotImplementedException();
    }

    //DO NOT Modify this code
    private async Task<bool> CreateAMovieWithGenre()
    {
        Console.WriteLine(new string('*', 60));
        Console.WriteLine("Creating a new movie with genre...");

        var existingItem = await _db.Items
            .Where(i => i.Name == "Blade Runner 2049")
            .SingleOrDefaultAsync();
        if (existingItem != null)
        {
            Console.WriteLine($"Movie 'Blade Runner 2049' already exists with ID: {existingItem.Id}");
            return true; // Exit if the movie already exists
        }

        // Create a new genre and category if they don't exist
        var genre = await _db.Genres.ToListAsync();
        var categories = await _db.Categories.ToListAsync();
        var movieCategory = categories.FirstOrDefault(c => c.CategoryName == "Movie") ??
                            new Category { CategoryName = "Movie", Description = "A category for movies." };
        var genreSciFi = genre.FirstOrDefault(g => g.GenreName == "Science Fiction") ??
                            new Genre { GenreName = "Science Fiction", IsActive = true };
        // Create a new genre for Dystopian (should not exist)
        var genreDystopian = genre.FirstOrDefault(g => g.GenreName == "Dystopian") ??
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

        _db.Items.Add(movie);
        await _db.SaveChangesAsync();

        Console.WriteLine($"Blade runner 2049 created with ID: {movie.Id}");
        Console.WriteLine(new string('*', 60));
        return true; // Indicate success
    }

    private async Task<bool> UpdateItemAndGenreNamesAsync(
        string originalItemName, string newItemName,
        string originalGenreName, string newGenreName)
    {
        /* TODO Use the code in listing 6-22 to complete this method*/
        throw new NotImplementedException();
    }


    private async Task<bool> UpdateMultipleItemsOnSale()
    {
        /* TODO: Use the code from Listing 6-24 to complete this method*/
        throw new NotImplementedException();
    }
}