# Listing 11-05: Using the FindAsync method

Use the baked-in Find Async to map to the known Id by default in the generic repository

## Using Find Async

Update the code in your class to the following:

```cs
public async Task<T?> GetByIdAsync(int id)
{
    return await _context.Set<T>().FindAsync(id);  
}
```  

This code will compile and run as expected, even though not every "class" will have an Id field.  EF has made this possible with baked-in logic.