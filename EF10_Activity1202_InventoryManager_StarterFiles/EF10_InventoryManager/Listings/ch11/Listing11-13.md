# Listing 11-13: Creating the GetByNameAsync  method

With the constraint in place and the code ready to go as implemented in the models, you can now filter by the Filter Name field

## The Code

Implement `GetByNameAsync(string name)` as follows:

```cs
public async Task<T?> GetByNameAsync(string name)
{
    var items = await _context.Set<T>().ToListAsync();
    return items.SingleOrDefault(e => e.FilterName == name);
}
```  

>**Note:** You have to pull the full list first, then filter on the client side because `FilterName` is `NotMapped` so there is no database table, and, therefore, no SQL query that can use `FilterName`.

If you wanted to use reflection, you could do something like this to find the mapped name and then use it in a LINQ statement

**From Copilot and Untested**

```cs
public async Task<T?> GetByNameAsync(string name)
{
    // Find the first mapped property ending with "Name"
    var nameProp = typeof(T).GetProperties()
        .FirstOrDefault(p =>
            p.Name.EndsWith("Name") &&
            p.PropertyType == typeof(string) &&
            !Attribute.IsDefined(p, typeof(System.ComponentModel.DataAnnotations.NotMappedAttribute))
        );

    if (nameProp == null)
        throw new InvalidOperationException($"No mapped 'Name' property found for type {typeof(T).Name}.");

    // Build a lambda expression: x => x.<NameProperty> == name
    var param = Expression.Parameter(typeof(T), "x");
    var propAccess = Expression.Property(param, nameProp);
    var value = Expression.Constant(name, typeof(string));
    var equals = Expression.Equal(propAccess, value);
    var lambda = Expression.Lambda<Func<T, bool>>(equals, param);

    return await _context.Set<T>().FirstOrDefaultAsync(lambda);
}
```  
