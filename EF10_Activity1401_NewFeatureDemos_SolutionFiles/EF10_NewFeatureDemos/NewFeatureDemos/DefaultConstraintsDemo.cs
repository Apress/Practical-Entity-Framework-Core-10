using EF10_NewFeaturesDbLibrary;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class DefaultConstraintsDemo : IAsyncDemo
{
    private readonly InventoryDbContext _db;

    public DefaultConstraintsDemo(InventoryDbContext db)
    {
        _db = db;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("There is no code for this demonstration");
        //use the listings as called out to modify default constraint names and then run a migration add and update.
    }
}

