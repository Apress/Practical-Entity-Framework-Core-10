using EF10_NewFeaturesDbLibrary;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class TpcDemo : IAsyncDemo
{
    private readonly InventoryDbContext _db;

    public TpcDemo(InventoryDbContext db)
    {
        _db = db;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("Please use the other files to complete this demo...");
    }
}

