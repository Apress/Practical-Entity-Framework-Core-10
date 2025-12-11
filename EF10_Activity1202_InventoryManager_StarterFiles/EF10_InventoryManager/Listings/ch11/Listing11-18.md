# Listing 11-18: FindAsync

Update the `FindAsync` method with the code as follows.

## The Code

```cs
public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
{
    return await _context.Set<T>().Where(predicate).ToListAsync();
}
```  

>**Note**: Instead of using mapped classes, you could use this expression predicate to filter by fields if necessary.