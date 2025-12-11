# Listing 11-15: AddAsync

Update the `AddAsync` method with the code as follows.

## The Code

Notice the code is calling first to add, then to save changes.

```cs
public async Task<bool> AddAsync(T entity)
{
    await _context.Set<T>().AddAsync(entity);
    return await _context.SaveChangesAsync() > 0;
}
```  