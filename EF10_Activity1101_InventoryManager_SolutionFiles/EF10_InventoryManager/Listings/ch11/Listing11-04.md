# Listing 11-04: The GetByIdAsync method won't work if you try to filter by Id

Use the following code to see that working with the `Id` field is not possible when there is no binding to a type with an Id field.

## The code

Place the following code in your class to see the error:

```cs
public async Task<T?> GetByIdAsync(int id)
{
    return await _context.Set<T>().Where(x => x.Id == id).SingleOrDefaultAsync();
}
```  

