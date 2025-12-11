# Listing 11-3: The Get All Async Method

Using generics and EF, you can get the values from any DbSet<T>

## The code

Implment the `GetAllAsync()` method as follows:

```cs
public async Task<List<T>> GetAllAsync()
{
    return await _context.Set<T>().ToListAsync();
}
```  