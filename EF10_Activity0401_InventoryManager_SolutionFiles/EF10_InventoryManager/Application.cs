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
        UpdateAllCurrentValue();
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
            new Item() { Name = "Top Gun", CurrentValue = 10.99m, Description = "Maverick and Goose"
                                , IsActive = true, IsOnSale = false, Notes = "I feel the need, the need for speed"
                                , PurchasedDate = new DateTime(2025, 7, 4), PurchasePrice = 9.99m, Quantity = 1, },
            new Item() { Name = "Star Wars", Quantity = 4, IsActive = true, IsOnSale = false},
            new Item() { Name = "Star Trek", Quantity = 1, IsActive = true, IsOnSale = true},
            new Item() { Name = "The Godfather", Quantity = 250, IsActive = true, IsOnSale = false},
            new Item() { Name = "The Lord of the Rings: The Fellowship of the Ring", Quantity = 10, IsActive = true, IsOnSale = false}
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
    
    private void UpdateAllCurrentValue()
    {
        
        var items = _db.Items.ToList();
        foreach (var item in items)
        {
            item.CurrentValue = 9.99M;
        }
        _db.Items.UpdateRange(items);
        _db.SaveChanges();
    }
}
