# Listing 9-4: Using `Select` to project properties of an object to an anonymous type

In this example, you will use the Select method to project properties of an object to an anonymous type. This is useful when you only need a subset of the properties from an entity.

## The Code

Use this code, replacing the `throw new NotImplementedException()` line that follows the comment `TODO: Add the code from listing 9-4` in the `ProjectToAnAnonymousClass` method with the actual LINQ query below:

```csharp
var multiGenreItems = _db.Items
        .Select(i => new
        {
            i.Id,
            i.Name,
            Genres = i.Genres.Select(ig => ig.GenreName).Distinct().ToList(),
            GenreCount = i.Genres.Select(ig => ig.Id).Distinct().Count()
        })
        .Where(x => x.GenreCount > 1)
        .OrderByDescending(x => x.GenreCount)
        .ToList();
```  
