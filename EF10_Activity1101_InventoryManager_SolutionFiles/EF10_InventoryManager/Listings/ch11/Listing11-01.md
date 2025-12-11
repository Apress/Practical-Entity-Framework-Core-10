# Listing 11-01: The IGenericRepository Interface

Every repository in the application should implement a generic repository interface that defines the basic operations for managing entities. This interface will provide a consistent contract for all repositories, allowing for easier maintenance and testing.

## The code

Use the code in the following listing to define the `IGenericRepository` interface, which provides a generic contract for repository operations on entities of type `T`. This interface includes methods for retrieving, adding, updating, and deleting entities, as well as a method for finding entities based on a predicate.

```csharp
namespace EF10_InventoryDataLayer;
using System.Linq.Expressions;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByNameAsync(string name);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);   
}
```  