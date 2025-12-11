using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;
using EF10_NewFeaturesModels;
using Microsoft.EntityFrameworkCore;

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
        Console.WriteLine("Running TPC Demo...");

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("TPC Demo Menu");
            Console.WriteLine("-------------");
            Console.WriteLine("1. Show Items (base entity)");
            Console.WriteLine("2. Show Books (concrete table)");
            Console.WriteLine("3. Show Movies (concrete table)");
            Console.WriteLine("4. Show MediaItems (union)");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ShowItems();
                    break;
                case "2":
                    await ShowBooks();
                    break;
                case "3":
                    await ShowMovies();
                    break;
                case "4":
                    await ShowMediaItems();
                    break;
                case "5":
                    exit = true;
                    continue;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        Console.WriteLine("TPC Demo complete.");
    }


    // -----------------------------------------------------------------
    private async Task ShowItems()
    {
        //-------------------------------------------------------
        //TODO Listing 14-27 -> Query all Items (base entity)
        var items = new List<Item>(); //replace this and uncomment the print out below
        

        //-------------------------------------------------------
        Console.WriteLine($"Item count: {items.Count}");
        if (items.Count > 0)
        {
            Console.WriteLine("All Items (base table query):");
            
            // Console.WriteLine(ConsolePrinter.PrintBoxedList(
            // items,
            // i => $"{i.Id} - {i.ItemName} - {i.CategoryName} - {i.Description} - onsale: {i.IsOnSale}"
            // ));
        }

        Console.WriteLine($"Item count: {items.Count}");
    }


    private async Task ShowBooks()
    {
        // -----------------------------------------------------------------
        //TODO Listing 14-28 -> Query Books (concrete table)
        var books = new List<Book>(); //replace this and uncomment the print out below

        //-----------------------------------------------------------------
        Console.WriteLine($"Book count: {books.Count}");
        if (books.Count > 0)
        {
            Console.WriteLine("Books (TPC concrete table query):");

            // Console.WriteLine(ConsolePrinter.PrintBoxedList(
            //     books,
            //     b => $"{b.Id} - {b.ItemName} - {b.CategoryName} - ISBN: {b.ISBN} - Plot: {b.PlotSummary}"
            // ));
        }
    }

    
    private async Task ShowMovies()
    {
        // -----------------------------------------------------------------
        //TODO Listing 14-29 -> Query Movies (concrete table)
        var movies = new List<Movie>(); //replace this and uncomment the print out below
        
        //-----------------------------------------------------------------
        Console.WriteLine($"Movie count: {movies.Count}");
        if (movies.Count > 0)
        {
            Console.WriteLine("Movies (TPC concrete table query):");
            
            // Console.WriteLine(ConsolePrinter.PrintBoxedList(
            //     movies,
            //     m => $"{m.Id} - {m.ItemName} - {m.CategoryName} - Rating: {m.MPAARating} - Plot: {m.PlotSummary}"
            // ));
        }
    }


    private async Task ShowMediaItems()
    {
        // -----------------------------------------------------------------
        //TODO Listing 14-30 -> Query MediaItems (abstract base with TPC union)
        var mediaItems = new List<MediaItem>(); //replace this and uncomment the print out below
        
        // -----------------------------------------------------------------
        Console.WriteLine($"MediaItem count (union): {mediaItems.Count}");
        if (mediaItems.Count > 0)
        {
            Console.WriteLine("MediaItems (union of Books + Movies under TPC):");
            
            // Console.WriteLine(ConsolePrinter.PrintBoxedList(
            //     mediaItems,
            //     mi => $"{mi.Id} - {mi.ItemName} - {mi.CategoryName} - Plot: {mi.PlotSummary} - Type: {mi.Type}"
            // ));
        }
    }
}
