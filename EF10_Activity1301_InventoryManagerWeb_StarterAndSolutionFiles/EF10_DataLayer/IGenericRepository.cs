using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

public interface IGenericRepository<T> where T : ActivatableIdentityModel
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByNameAsync(string name);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
