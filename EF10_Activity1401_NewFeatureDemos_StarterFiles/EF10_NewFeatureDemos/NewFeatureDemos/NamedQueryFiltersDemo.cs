using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;
using EF10_NewFeaturesModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class NamedQueryFiltersDemo : IAsyncDemo
{
    private readonly InventoryDbContext _db;

    public NamedQueryFiltersDemo(InventoryDbContext db)
    {
        _db = db;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("Running Named Query Filters Demo...");

        //first, show all categories with the filter applied (IsDeleted = false)
        var allCategories = await _db.Categories.ToListAsync();
        Console.WriteLine(ConsolePrinter.PrintBoxedList(allCategories
            , c => $"{c.Id}: {c.CategoryName} [IS Deleted: {c.IsDeleted}] - [Is Active {c.IsActive}]"));

        //--------------------------------------------------
        //TODO: Listing 14-7 -> Show ALL categories, even the "deleted" ones
        List<Category> allIncludingDeleted = new List<Category>();


        //-------------------------------------------------------------------------------------
        //TODO: Listing 14-8 -> Make the toy/collectable category inactive
        List<Item> itemsForFunko = new List<Item>();


        //-------------------------------------------------------------------------------------



    }
}

