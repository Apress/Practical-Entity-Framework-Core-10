using AutoMapper;
using EF10_InventoryDBLibrary;
using EF10_InventoryManager.ConsoleHelpers;
using EF10_InventoryModels;
using EF10_InventoryServiceLayer;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager;

public class Application
{
    private readonly InventoryDbContext _db;
    private readonly MainMenu _menu;
    private const int _lineLength = 50;
    private static IMapper _mapper;

    public Application(InventoryDbContext context, IMapper mapper, IItemService itemService
                            , ICategoryService category, IContributorService contributorService
                            , IGenreService genreService)
    {
        _db = context;
        _mapper = mapper;
        _menu = new MainMenu(context, _lineLength, _mapper, itemService, category, contributorService, genreService);
    }

    public async Task DoWork()
    {
        Console.WriteLine("Welcome to the Inventory Manager");
        Console.WriteLine(new string('*', 60));

        var canConnect = await EnsureConnection();
        Console.WriteLine($"Connection Established: {(canConnect ? "Yes" : "No")}");

        await _menu.ShowAsync();

        Console.WriteLine("Thank you for using the Inventory Manager System!");
    }

    private async Task<bool> EnsureConnection()
    {
        var canConnect = await _db.Database.CanConnectAsync();
        return canConnect;
    }
}
