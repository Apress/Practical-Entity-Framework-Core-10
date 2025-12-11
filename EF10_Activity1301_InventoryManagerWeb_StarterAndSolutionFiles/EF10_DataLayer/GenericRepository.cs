using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

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

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        //return await _context.Set<T>().FindAsync(id);  //with `where T is class`
        return await _context.Set<T>().Where(x => x.Id == id).SingleOrDefaultAsync(); //with `where T is ActivatableIdentityModel (IdentityModel)`
    }

    public async Task<T?> GetByNameAsync(string name)
    {
        var items = await _context.Set<T>().ToListAsync();
        return items.SingleOrDefault(e => e.FilterName == name);
    }
    public async Task<bool> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }
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
                    !(p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() != typeof(Nullable<>)) &&
                    !(typeof(System.Collections.IEnumerable).IsAssignableFrom(p.PropertyType)
                      && p.PropertyType != typeof(string)) &&
                    p.Name != "Id");

        foreach (var prop in properties)
        {
            var value = prop.GetValue(entity);
            prop.SetValue(entityToUpdate, value);
        }

        _context.Set<T>().Update(entityToUpdate);
        return await _context.SaveChangesAsync() > 0;
    }

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

    public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }
}
