using EF10_InventoryDBLibrary;
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
        
        var cnstr = _db.Database.GetConnectionString();
        Console.WriteLine(cnstr);

        var canConnect = await EnsureConnection();
        Console.WriteLine($"Connection Established: {(canConnect ? "Yes" : "No")}");

	    Console.WriteLine(new string('*', 60));
        Console.WriteLine("Thank you for using the Inventory Manager System!");
    }

    private async Task<bool> EnsureConnection()
    {
        var canConnect = await _db.Database.CanConnectAsync();
        return canConnect;
    }
    
}
