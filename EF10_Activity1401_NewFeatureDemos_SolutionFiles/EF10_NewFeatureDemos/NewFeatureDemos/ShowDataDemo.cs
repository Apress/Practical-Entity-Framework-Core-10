using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;
using EF10_NewFeaturesModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class ShowDataDemo : IAsyncDemo
{
    private readonly InventoryDbContext _db;

    public ShowDataDemo(InventoryDbContext db)
    {
        _db = db;   
    }

    public async Task RunAsync()
    {
        Console.WriteLine("Showing Data...");

        var itemsData = await _db.Items
            .AsNoTracking()
            .Select(i => new
            {
                i.Id,
                i.ItemName,
                CategoryName = i.Category.CategoryName,
                i.IsOnSale,

                // Correlated subquery -> STRING_AGG (no DISTINCT)
                ContributorsCsv = string.Join(", ",
                    i.ItemContributors
                    .Where(ic => ic.ContributorId != null && ic.Contributor != null)
                    .Select(ic => ic.Contributor!.ContributorName)
                    .Distinct()  // <-- only if you're on SQL 2022+
                ),

                GenresCsv = string.Join(", ",
                    i.Genres
                    .Select(g => g.GenreName)
                    .Distinct()  // <-- only if you're on SQL 2022+
                )
            })
            .ToListAsync();

        Console.WriteLine(
            ConsolePrinter.PrintBoxedList(
                itemsData, i => $"{i.Id} - {i.ItemName} - {i.CategoryName} - {i.IsOnSale} - " +
                                    $"{(string.IsNullOrWhiteSpace(i.GenresCsv) ? "No Genres" : i.GenresCsv)} - " +
                                    $"{(string.IsNullOrWhiteSpace(i.ContributorsCsv) ? "No Contributors" : i.ContributorsCsv)}"));

        //-----------------------------------------------------------------
        Console.WriteLine($"Number of items: {itemsData.Count}");
        Console.WriteLine("Items shown successfully.");
    }
}
