# Listing 11-17: DeleteAsync

Update the `DeleteAsync` method with the code as follows.

## The Code

```cs
public async Task<bool> DeleteAsync(int id)
{
    var entity = await GetByIdAsync(id);
    if (entity == null)
    {
        return false;
    }
    _context.Set<T>().Remove(entity);
    return await _context.SaveChangesAsync() > 0;
}
```  