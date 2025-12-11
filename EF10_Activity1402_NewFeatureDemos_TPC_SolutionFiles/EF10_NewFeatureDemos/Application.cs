using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;

namespace EF10_NewFeatureDemos;

public class Application
{
    private readonly MainMenu _menu;

    public Application(InventoryDbContext db)
    {
        _menu = new MainMenu(db);
    }

    public async Task DoWork()
    {
        Console.WriteLine("Welcome to the New Feature Demos");

        await _menu.ShowAsync();

        Console.WriteLine("Thank you for using the New Feature Demos!");
    }
}
