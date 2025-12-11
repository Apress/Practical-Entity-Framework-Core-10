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
        //Listing 14-7 -> Show ALL categories, even the "deleted" ones
        List<Category> allIncludingDeleted = await _db.Categories
                                                        .IgnoreQueryFilters(new[] { "SoftDelete" })
                                                        .ToListAsync();

        Console.WriteLine(ConsolePrinter.PrintBoxedList(allIncludingDeleted
            , c => $"{c.Id}: {c.CategoryName} [IS Deleted: {c.IsDeleted}] - [Is Active {c.IsActive}]"));


        //--------------------------------------------------
        //Listing 14-8 -> Make the toy/collectable category inactive
        var toyCategory = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryName == "Toy/Collectable");
        if (toyCategory != null)
        {
            toyCategory.IsActive = false;
            await _db.SaveChangesAsync();
        }

        //show the categories again (should not see the toy category now)
        allCategories = await _db.Categories.ToListAsync();
        Console.WriteLine(ConsolePrinter.PrintBoxedList(allCategories
            , c => $"{c.Id}: {c.CategoryName} [IS Deleted: {c.IsDeleted}] - [Is Active {c.IsActive}]"));

        //toggle the filter to show inactive categories
        List<Category> includeInactive = await _db.Categories
                                                    .IgnoreQueryFilters(new[] { "Active" })
                                                    .ToListAsync();
        Console.WriteLine(ConsolePrinter.PrintBoxedList(includeInactive
            , c => $"{c.Id}: {c.CategoryName} [IS Deleted: {c.IsDeleted}] - [Is Active {c.IsActive}]"));
    }
}

