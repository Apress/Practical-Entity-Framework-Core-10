using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;
using EF10_NewFeaturesModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class InterceptorsAndLoggingDemo : IAsyncDemo
{
    private readonly InventoryDbContext _db;

    public InterceptorsAndLoggingDemo(InventoryDbContext db)
    {
        _db = db;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("Running Interceptors and Logging Demo...");

        var categories = await _db.Categories.ToListAsync();
        Console.WriteLine(ConsolePrinter.PrintBoxedList(categories
            , c => $"{c.Id}: {c.CategoryName} [IS Deleted: {c.IsDeleted}] - [Is Active {c.IsActive}]"));

        var ts = DateTime.Now.ToString("yyyyMMddHHmmss");
        //--------------------------------------------------
        //TODO: Listing 14-5 -> Add a new Category, then "delete" it (soft delete should occur)


        
        //--------------------------------------------------

        var currentCategories = await _db.Categories.ToListAsync();
        Console.WriteLine(ConsolePrinter.PrintBoxedList(currentCategories
            , c => $"{c.Id}: {c.CategoryName} [IS Deleted: {c.IsDeleted}] - [Is Active {c.IsActive}]"));
    }
}
