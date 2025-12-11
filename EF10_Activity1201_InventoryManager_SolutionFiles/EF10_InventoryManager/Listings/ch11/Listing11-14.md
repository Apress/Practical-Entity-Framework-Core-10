# Listing 11-14: Using Id in GetById works now

Optionally, you can ditch the FindAsync method and replace with code at will for the Id now.

## the code

```cs
public async Task<T?> GetByIdAsync(int id)
{
    return await _context.Set<T>().Where(x => x.Id == id).SingleOrDefaultAsync();
}
```  
