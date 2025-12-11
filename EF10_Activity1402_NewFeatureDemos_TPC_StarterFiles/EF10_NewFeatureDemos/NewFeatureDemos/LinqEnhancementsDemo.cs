using Azure.Identity;
using EF10_NewFeatureDemos.ConsoleHelpers;
using EF10_NewFeaturesDbLibrary;
using EF10_NewFeaturesModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_NewFeatureDemos.NewFeatureDemos;

public class LinqEnhancementsDemo : IAsyncDemo
{
    private readonly InventoryDbContext _db;

    public LinqEnhancementsDemo(InventoryDbContext db)
    {
        _db = db;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("Running Linq Enhancements Demo...");

        //Ensure a couple of contributors with no items associated exist
        EnsureContributors();

        //use the original way to get contributors with no items
        ShowContributorReportDataOldWay();

        //use the new way to get contributors with no items
        ShowContributorReportDataNewWay();

        //Get Items by a list of Genre Names
        //-------------------------------------------------
        //Put the code from Listing 14-24 here:
        var genres = new List<string> { "Sci-Fi", "Fantasy", };
        var itemsByGenres = _db.Items
                                .Include(i => i.Genres)
                                .Where(i => i.Genres.Any(g => genres.Contains(g.GenreName)));

        //-------------------------------------------------
        if (itemsByGenres.Count() > 0)
        {
            Console.WriteLine(ConsolePrinter.PrintBoxedList(itemsByGenres, i => $"{i.ItemName} - Genres: {string.Join(", ", i.Genres.Select(g => g.GenreName))}"));
        }
    }

    private void ShowContributorReportDataNewWay()
    {
        //the new way to get contributors with no items associated

        //-------------------------------------------------------------------
        //TODO: Put the code from Listing 14-22 here:  
        var query = _db.Contributors
                    .LeftJoin(
                        _db.ItemContributors,
                        c => c.Id,
                        ic => ic.ContributorId,
                        (c, ic) => new { Contributor = c, ItemContributor = ic }
                    )
                    .GroupBy(x => x.Contributor)
                    .Select(g => new
                    {
                        ContributorName = g.Key.ContributorName,
                        ItemCount = g.Count(x => x.ItemContributor != null) // → 0 when none
                    })
                    .ToList();


        //-------------------------------------------------------------------
        Console.WriteLine("Contributors and their item counts (new way):");
        //Console.WriteLine(ConsolePrinter.PrintBoxedList(query, x => $"{x.ContributorName}: {x.ItemCount} items"));  //uncomment when query is done
    }

    private void EnsureContributors()
    {
        var contributorNames = new[] { "No Items Contributor 1", "No Items Contributor 2" };
        foreach (var name in contributorNames)
        {
            var exists = _db.Contributors.Any(c => c.ContributorName == name);
            if (!exists)
            {
                _db.Contributors.Add(new EF10_NewFeaturesModels.Contributor
                {
                    ContributorName = name,
                    IsActive = true
                });
            }
        }
        _db.SaveChanges();
    }

    private void ShowContributorReportDataOldWay()
    {
        //the old way to get contributors with no items associated
        //this is the code from listing 14-20:
        var query = _db.Contributors
            .GroupJoin(
                _db.ItemContributors,
                c => c.Id,
                ic => ic.ContributorId,
                (c, ics) => new { Contributor = c, ItemContributors = ics }
            )
            .SelectMany(
                x => x.ItemContributors.DefaultIfEmpty(),
                (x, ic) => new { x.Contributor, ItemContributor = ic }
            )
            .GroupBy(x => x.Contributor)
            .Select(g => new
            {
                ContributorName = g.Key.ContributorName,
                ItemCount = g.Count(x => x.ItemContributor != null)  // counts items safely
            })
            .ToList();

        Console.WriteLine("Contributors and their item counts (old way):");
        Console.WriteLine(ConsolePrinter.PrintBoxedList(query, x => $"{x.ContributorName}: {x.ItemCount} items"));
    }
}

