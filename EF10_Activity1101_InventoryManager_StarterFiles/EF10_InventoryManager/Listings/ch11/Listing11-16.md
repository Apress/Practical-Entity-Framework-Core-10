# Listing 11-16: UpdateAsync

Update the `UpdateAsync` method with the code as follows.

## The Code

Use this code to replace the stuf for `UpdateAsync(T entity)`

```cs
public async Task<bool> UpdateAsync(T entity)
{
    var entityToUpdate = await GetByIdAsync(entity.Id);
    if (entityToUpdate == null)
    {
        return false; // or throw an exception if preferred
    }
    // use reflection to map properties from entity to entityToUpdate
    var type = typeof(T);
    var properties = type.GetProperties()
        .Where(p => p.CanWrite && p.CanRead &&
                    !Attribute.IsDefined(p, typeof(System.ComponentModel.DataAnnotations.KeyAttribute)) &&
                    !p.PropertyType.IsGenericType &&
                    !typeof(System.Collections.IEnumerable).IsAssignableFrom(p.PropertyType) &&
                    p.Name != "Id");

    foreach (var prop in properties)
    {
        var value = prop.GetValue(entity);
        prop.SetValue(entityToUpdate, value);
    }

    _context.Set<T>().Update(entityToUpdate);
    return await _context.SaveChangesAsync() > 0;
}
```  