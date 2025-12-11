using EF10_AWDBLibrary;
using EF10_AWDBLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EF10_Activity0301;

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

        var canConnect = await EnsureConnection();
        Console.WriteLine($"Connection Established: {(canConnect ? "Yes" : "No")}");

        Console.WriteLine("Starting Customer Retrieval");
        var customers = await GetCustomers(20);
        customers.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));

        Console.WriteLine("done");
    }

    public async Task<bool> EnsureConnection()
    {
        var canConnect = await _db.Database.CanConnectAsync();
        return canConnect;
    }

    public async Task<List<Customer>> GetCustomers(int howMany)
    {
        return await _db.Customers
                        .Select(c => new { c.FirstName, c.LastName })
                        .Distinct()
                        .OrderBy(c => c.LastName)
                        .Take(howMany)
                        .Select(c => new Customer { FirstName = c.FirstName, LastName = c.LastName })
                        .ToListAsync();
    }
}
