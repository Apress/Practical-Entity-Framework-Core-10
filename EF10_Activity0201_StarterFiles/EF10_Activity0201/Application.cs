using EF10_AWDBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF10_Activity0201;

public class Application
{
    private readonly AdventureWorksContext _db;

    public Application(AdventureWorksContext context)
    {
        _db = context;   
    }

    public async Task DoWork()
    {
        Console.WriteLine("Welcome to the Adventureworks: database-first!");

        var cnstr = _db.Database.GetConnectionString();
        Console.WriteLine($"{cnstr}");

        var canConnect = await EnsureConnection();
        Console.WriteLine($"Connection Established: {(canConnect ? "Yes" : "No")}");

        Console.WriteLine("Starting Customer Retrieval");
        
        Console.WriteLine("done");
    }

    public async Task<bool> EnsureConnection()
    {
        var canConnect = await _db.Database.CanConnectAsync();
        return canConnect;
    }
}
