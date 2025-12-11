using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;
using EF10_NewFeaturesModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class BulkDeleteDemo : IAsyncDemo
{
    private readonly InventoryDbContext _db;

    public BulkDeleteDemo(InventoryDbContext db)
    {
        _db = db;   
    }

    public async Task RunAsync()
    {
        //the old way (for reference only):
        //var movies = await _db.Items.Where(i => i.Category.CategoryName == "Movie").ToListAsync();
        //foreach (var movie in movies)
        //{
        //    _db.Items.Remove(movie);
        //}
        //await _db.SaveChangesAsync();

        //the new way -> use ExecuteDeleteAsync()
        Console.WriteLine("Running Bulk Delete Demo...");

        //clear:
        await _db.JunkToBulkDeletes.ExecuteDeleteAsync();

        //create junk to delete
        CreateJunkToDelete();

        //show it
        var jtd = await _db.JunkToBulkDeletes.ToListAsync();
        Console.WriteLine(ConsolePrinter.PrintBoxedList(jtd, j => $"{j.Id}: {j.Name}"));

        //-----------------------------------------------------------------
        //Listing 14-10, Delete All Junk To Delete
        int countJTD = await _db.JunkToBulkDeletes
                                .Where(j => j.Name.Contains("BadData"))
                                .ExecuteDeleteAsync();

        //-----------------------------------------------------------------
        //validate the deletion
        var current = await _db.JunkToBulkDeletes.ToListAsync();
        Console.WriteLine($"Number of junk items deleted: {countJTD}");
        Console.WriteLine($"Number of junk items remaining: {current.Count}");
        Console.WriteLine(ConsolePrinter.PrintBoxedList(current, j => $"{j.Id}: {j.Name}"));

        var wiped = await _db.JunkToBulkDeletes.ExecuteDeleteAsync();
        Console.WriteLine($"Final cleanup: {wiped} rows removed.");
        var validate = await _db.JunkToBulkDeletes.ToListAsync();
        Console.WriteLine($"Number of junk items remaining: {validate.Count} SHOULD BE 0");
    }

    private void CreateJunkToDelete()
    {
        var junkList = new List<JunkToBulkDelete>();
        for (int i = 1; i <= 10; i++)
        {
            junkList.Add(new JunkToBulkDelete
            {
                Name = $"Junk Item {i} {(i % 2== 0 ? "baddata" : string.Empty)}"
            });
        }
        _db.JunkToBulkDeletes.AddRange(junkList);
        _db.SaveChanges();
        Console.WriteLine("Created junk items to delete.");
    }
}
