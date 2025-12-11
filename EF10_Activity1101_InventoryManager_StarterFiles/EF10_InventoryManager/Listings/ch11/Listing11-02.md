# Listing 11-02: The stub for the GenericRepository

The Generic Repository Implementation.  Includes method stubs to be completed throughout the activity.

## The code

Use the following to provide the shell for method implementation for the generic repository:

```cs
public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly InventoryDbContext _context;

    public GenericRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        //Listing 11-3
        //TODO: Implement the logic to retrieve all entities from the database
        throw new NotImplementedException("GetAllAsync method not implemented.");
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        //Listing 11-4 && then 11-5 [alternate version later in 11-14]
        //TODO: Implement the logic to retrieve all entities from the database
        throw new NotImplementedException("GetByIdAsync method not implemented.");
    }

    public async Task<T?> GetByNameAsync(string name)
    {
        //Listing 11-13
        //TODO: Implement the logic to retrieve an entity by name from the database
        throw new NotImplementedException("GetByNameAsync method not implemented.");
    }

    public async Task<bool> AddAsync(T entity)
    {
        //Listing 11-15
        //TODO: Implement the logic to add an entity to the database
        throw new NotImplementedException("AddAsync method not implemented.");
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        //Listing 11-16
        //TODO: Implement the logic to update an entity in the database
        throw new NotImplementedException("UpdateAsync method not implemented.");
    }

    public async Task<bool> DeleteAsync(int id)
    {
        //Listing 11-17
        //TODO: Implement the logic to delete an entity by id from the database
        throw new NotImplementedException("DeleteAsync method not implemented.");
    }

    public async Task<List<T>> FindAsync(Func<T, bool> predicate)
    {
        //Listing 11-18
        //TODO: Implement the logic to find entities based on a predicate
        throw new NotImplementedException("FindAsync method not implemented.");
    }
}
```  