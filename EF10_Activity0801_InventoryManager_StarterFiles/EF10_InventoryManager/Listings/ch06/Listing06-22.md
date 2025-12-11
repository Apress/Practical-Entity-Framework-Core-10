# Listing 6-22: Update Item and Genre Names

Update both the Item and the Genre object to have new names

## The code

Use this code to complete the `UpdateItemAndGenreNamesAsync` method:

```cs
public async Task<bool> UpdateItemAndGenreNamesAsync(
    string originalItemName, string newItemName,
    string originalGenreName, string newGenreName)
{
    var item = await _db.Items
        .Include(i => i.Genres)
        .Where(i => i.Name == originalItemName &&
                    i.Genres.Any(g => g.GenreName == originalGenreName))
        .SingleOrDefaultAsync();
    if (item == null)
    { 
        Console.WriteLine("Item or genre not found.");
        return false; //indicate failure
    }
    item.Name = newItemName;
    var genre = item.Genres?.FirstOrDefault(g => g.GenreName == originalGenreName);
    if (genre != null)
    {
        genre.GenreName = newGenreName;
    }
    _db.Items.Update(item);
    await _db.SaveChangesAsync();
    return true;
}
```  