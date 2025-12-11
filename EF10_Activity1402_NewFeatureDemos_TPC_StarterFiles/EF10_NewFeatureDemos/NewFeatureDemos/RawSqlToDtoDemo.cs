using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;
using EF10_NewFeaturesModels;
using EF10_NewFeaturesModels.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class RawSqlToDtoDemo : IAsyncDemo
{
    private readonly InventoryDbContext _db;

    public RawSqlToDtoDemo(InventoryDbContext db)
    {
        _db = db;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("Running Raw SQL to DTO Demo...");
        List<ItemDetailSummaryDTO> itemsNewWay = new List<ItemDetailSummaryDTO>();
        //--------------------------------------------------
        //Listing 14-18 -> Use SqlQuery to populate a DTO
        //get the items
        itemsNewWay = await _db.Database
            .SqlQuery<ItemDetailSummaryDTO>(
                $"SELECT * FROM vwGetItemDetailSummaries")
            .ToListAsync();

        //--------------------------------------------------
        //print them
        Console.WriteLine(ConsolePrinter.PrintBoxedList(itemsNewWay, x => $"{x.ItemId} | {x.ItemName} | {x.CategoryName} | {x.Genres} | {x.Contributors}"));
    }
}
