# Listing 11-27: The first part of the bulk load method

Use this code for the first part of the bulk load method

## The code

```cs
var itemContributorsToAdd = new List<ItemContributor>();
var genreStubs = new Dictionary<int, Genre>();

//stub in genres first to avoid tracking conflicts
//Only doing this to cause invalid genre ids to make it to the transaction
//if you used a list of genres, you would just attach the existing genre and you'd be good
//or even add if it doesn't exist (but you'd need genre information).
foreach (var parsed in parsedItems)
{
    foreach (var genreId in parsed.GenreIds)
    {
        if (!genreStubs.TryGetValue(genreId, out var genreStub))
        {
            genreStub = _context.Genres.Local.FirstOrDefault(g => g.Id == genreId);
            if (genreStub == null)
            {
                genreStub = new Genre { Id = genreId };
                _context.Attach(genreStub);
            }
            genreStubs[genreId] = genreStub;
        }
        parsed.Item.Genres.Add(genreStub);
    }
}
```  