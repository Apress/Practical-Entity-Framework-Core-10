using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;
using Microsoft.EntityFrameworkCore;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class BulkUpdateDemo : IAsyncDemo
{
    private readonly InventoryDbContext _db;

    public BulkUpdateDemo(InventoryDbContext db)
    {
        _db = db;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("Running Bulk Update Demo...");

        //the old way (for reference only):
        //var movies = await _db.Items.Where(m => m.CategoryId == 1).ToListAsync();
        //foreach (var movie in movies)
        //{
        //    movie.IsOnSale = true;
        //}
        //await _db.SaveChangesAsync();
        //Note: Requires that the context is tracking the entities
        //      you must iterate through the entities and set the properties
        //      Also, SaveChangesAsync() is required to persist the changes

        //the new way:
        //-----------------------------------------------------------------
        //Listing 14-9, Update All Movies to be on sale
        int countMovies = await _db.Items
                    .Where(m => m.Category.CategoryName == "Movie")
                    .ExecuteUpdateAsync(s =>
                        s.SetProperty(i => i.IsOnSale, i => true)
                    );

        //-----------------------------------------------------------------
        //note: NO MORE SaveChangesAsync() is needed!!!
        //note the execute update method returns the number of rows updated

        //get the movies to a list
        var movies = await _db.Items.Where(m => m.Category.CategoryName == "Movie").ToListAsync();
        Console.WriteLine(
            ConsolePrinter.PrintBoxedList(
                movies, m => $"{m.Id} -{m.ItemName} - {m.IsOnSale}"));

        Console.WriteLine("Movies updated successfully.");
        Console.WriteLine($"Number of movies updated: {countMovies}");
    }
}
