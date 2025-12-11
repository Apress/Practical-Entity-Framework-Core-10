# Listing 6-19: Update the Genre with an implicit update

The ability to update a `Genre` entity without explicitly calling `Update` when the entity is tracked by EF Core.

## The code  

Use the code below to update a `Genre` implicitly.  The entity is tracked by EF Core, so there is no need to call `Update`.  

```cs
public async Task<bool> UpdateGenreChangeNameImplicitUpdateDemo(string genreName, string newGenreName)
{
    var genre = await _db.Genres.SingleOrDefaultAsync(g => g.GenreName == genreName);
    if (genre == null)
    {
        Console.WriteLine("Genre not found.");
        return false; //indicate failure
    }
    //modify the genre name
    genre.GenreName = newGenreName; //change the name
    //do not explicitly call Update, as EF Core tracks the entity
    return await _db.SaveChangesAsync() == 1; //return true if one row was updated
}
```  