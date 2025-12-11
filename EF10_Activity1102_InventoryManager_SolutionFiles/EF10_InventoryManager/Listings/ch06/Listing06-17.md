# Listing 6-17: Update the Genre with a disconnect and no key

The ability to update a `Genre` entity when the entity is disconnected and no key is provided is problematic.

The first attempt to update the entity will perform an Add.  
The second attempt to update will fail because the entity already exists by name.

## The code

The code performs an `Upsert` instead of an update.

```cs
public async Task<bool> UpdateGenreBadDemo()
{
    //the data was seeded, so it is guaranteed to exist, but no key was leveraged:
    var genre = new Genre { GenreName = "Science Fiction" };
    genre.GenreName = "Sci-Fi"; //change the name
    try
    {
        //this will throw an exception because the entity is not tracked
        _db.Genres.Update(genre);
    }
    catch (DbUpdateConcurrencyException ex)
    {
        Console.WriteLine($"Concurrency error: {ex.Message}");
        return false; //indicate failure
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error updating genre: {ex.Message}");
        return false; //indicate failure
    }

    return await _db.SaveChangesAsync() == 1; //return true if one row was updated
}
```