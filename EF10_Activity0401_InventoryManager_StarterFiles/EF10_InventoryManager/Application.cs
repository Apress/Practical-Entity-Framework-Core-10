using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryManager;

public class Application
{
    private readonly InventoryDbContext _db;

    public Application(InventoryDbContext context)
    {
        _db = context;
    }

    public async Task DoWork()
    {
        Console.WriteLine("Welcome to the Inventory Manager");
        Console.WriteLine(new string('*', 60));

        // var cnstr = _db.Database.GetConnectionString();
        // Console.WriteLine(cnstr);

        var canConnect = await EnsureConnection();
        Console.WriteLine($"Connection Established: {(canConnect ? "Yes" : "No")}");

        await EnsureItemsExistAsync();

        var items = await GetAllItemsAsync();
        Console.WriteLine(new string('-', 60));
        Console.WriteLine("Items:");
        Console.WriteLine(new string('-', 60));
        items.ForEach(x => Console.WriteLine($"Item: {x.Name}"));


        Console.WriteLine(new string('*', 60));
        Console.WriteLine("Thank you for using the Inventory Manager System!");
    }

    private async Task<bool> EnsureConnection()
    {
        var canConnect = await _db.Database.CanConnectAsync();
        return canConnect;
    }

    public async Task EnsureItemsExistAsync()
    {
        List<Item> items = new()
        {
            new Item() { Name = "Top Gun"},
            new Item() { Name = "Star Wars"},
            new Item() { Name = "Star Trek"},
            new Item() { Name = "The Godfather"},
            new Item() { Name = "The Lord of the Rings: The Fellowship of the Ring"}
        };

        bool modified = false;
        foreach (var item in items)
        {
            var existing = await _db.Items.SingleOrDefaultAsync(x => x.Name == item.Name);
            if (existing is null)
            {
                await _db.Items.AddAsync(item);
                modified = true;
            }
        }
        if (modified)
        {
            await _db.SaveChangesAsync();
        }
    }

    public async Task<List<Item>> GetAllItemsAsync()
    {
        return await _db.Items.OrderBy(x => x.Name).ToListAsync();
    }
}
