# Listing 11-12: The ability to constrain the type will make the code for specific fields work

Update the `where T is class` statements and replace with a new constraint.

## The code

Use the following constraint declarations on the generic repository:

```cs
where T : ActivatableIdentityModel
```  

Full declarations follow:

### Interface:

```cs
public interface IGenericRepository<T> where T : ActivatableIdentityModel
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByNameAsync(string name);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<List<T>> FindAsync(Func<T, bool> predicate);   
}
```  

### Implementation:

```cs
public abstract class GenericRepository<T> : IGenericRepository<T> where T : ActivatableIdentityModel
{
    protected readonly InventoryDbContext _context;

    public GenericRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);  
    }

    public async Task<T?> GetByNameAsync(string name)
    {
        //TODO: Implement the logic to retrieve an entity by name from the database
        throw new NotImplementedException("GetByNameAsync method not implemented.");
    }
    public async Task<bool> AddAsync(T entity)
    {
        //TODO: Implement the logic to add an entity to the database
        throw new NotImplementedException("AddAsync method not implemented.");
    }
    public async Task<bool> UpdateAsync(T entity)
    {
        //TODO: Implement the logic to update an entity in the database
        throw new NotImplementedException("UpdateAsync method not implemented.");
    }
    public async Task<bool> DeleteAsync(int id)
    {
        //TODO: Implement the logic to delete an entity by id from the database
        throw new NotImplementedException("DeleteAsync method not implemented.");
    }
    public async Task<List<T>> FindAsync(Func<T, bool> predicate)
    {
        //TODO: Implement the logic to find entities based on a predicate
        throw new NotImplementedException("FindAsync method not implemented.");
    }
}

```  