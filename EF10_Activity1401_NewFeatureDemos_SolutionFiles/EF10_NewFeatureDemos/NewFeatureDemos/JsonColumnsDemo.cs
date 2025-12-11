using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;
using EF10_NewFeaturesModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class JsonColumnsDemo : IAsyncDemo
{
    private readonly InventoryDbContext _db;

    public JsonColumnsDemo(InventoryDbContext db)
    {
        _db = db;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("Running Json Columns Demo...");
        //ensure all the contributors have some random metadata for their addresses
        RandomUpdateContributors();

        List<Contributor> contributorsInCity = new List<Contributor>();
        List<Contributor> contributorsWithPOBox = new List<Contributor>();
        //-------------------------------------------------
        //TODO Listing 14-14 -> Query Contributors by City in Address JSON column
        //Use the new JSON column mapping feature to query contributors by city
        var cityToFind = "Lakeside";

        contributorsInCity = await _db.Contributors
            .Where(c => c.Address != null
                    && c.Address.City == cityToFind)
            .ToListAsync();

        //-------------------------------------------------
        //print them
        Console.WriteLine($"Contributors in {cityToFind}:");
        Console.WriteLine(ConsolePrinter.PrintBoxedList(contributorsInCity, c => $"{c.ContributorName} - {c.Address?.AddressLine1}, {c.Address?.City}, {c.Address?.State} {c.Address?.PostalCode}"));

        //-------------------------------------------------
        //TODO Listing 14-15 -> Query Contributors with PO Box in Address JSON column
        contributorsWithPOBox = await _db.Contributors
                                    .Where(c => c.Address != null && c.Address.AddressLine1
                                            != null && c.Address.AddressLine1.StartsWith("PO Box"))
                                    .ToListAsync();

        //-------------------------------------------------
        //print results:
        if (contributorsWithPOBox.Count > 0)
        {
            Console.WriteLine($"Contributors with PO Box addresses:");
            Console.WriteLine(ConsolePrinter.PrintBoxedList(contributorsWithPOBox, c => $"{c.ContributorName} - {c.Address?.AddressLine1}, {c.Address?.City}, {c.Address?.State} {c.Address?.PostalCode}"));
        }

        Console.WriteLine("Json Columns Demo completed.");
    }

    private void RandomUpdateContributors()
    {
        var rand = new Random();
        //get all the contributors
        var contributors = _db.Contributors.ToList();
        foreach (var contributor in contributors)
        {
            if (contributor.Address != null) continue;
            // Randomly update the Metadata JSON column
            contributor.Address = CreateRandomAddress();
        }
        _db.SaveChanges();

        Console.WriteLine("Updated contributor metadata with random values.");
    }

    private Address CreateRandomAddress()
    {
        var rand = new Random();
        var streetNumber = rand.Next(100, 9999);
        var streets = new[] { "Main St", "Oak St", "Pine St", "Maple Ave", "Cedar Ln" };
        var cities = new[] { "Blue River", "Lime Springs", "Lakeside", "Hillview", "Greenville" };
        var states = new[] { "CA", "TX", "NY", "FL", "IL" };
        var zipCodes = new[] { "12345", "67890", "54321", "09876", "11223" };
        var POBoxNumbers = new[] { "PO Box 100", "PO Box 200", "PO Box 300", "PO Box 400", "PO Box 500" };
        var usePOBox = rand.Next(0, 5) == 3; // 20% chance to use PO Box
        var addressLine1 = usePOBox ? POBoxNumbers[rand.Next(POBoxNumbers.Length)] : $"{streetNumber} {streets[rand.Next(streets.Length)]}";
        var addressLine2 = usePOBox ? null : (rand.Next(0, 2) == 1 ? $"Apt {rand.Next(1, 1000)}" : "");
        return new Address
        {
            AddressLine1 = addressLine1,
            AddressLine2 = addressLine2,
            City = cities[rand.Next(cities.Length)],
            State = states[rand.Next(states.Length)],
            PostalCode = zipCodes[rand.Next(zipCodes.Length)]
        };
    }
}

