using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

//Updated to use ActivatableIdentityModel as base class from Listing 11-12
public abstract class GenericRepository<T> : IGenericRepository<T> where T : ActivatableIdentityModel
{
    protected readonly InventoryDbContext _context;

    public GenericRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        //Listing 11-3
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        //Listing 11-4 && then 11-5 [alternate version later in 11-14]
        //return await _context.Set<T>().Where(x => x.Id == id).SingleOrDefaultAsync();
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T?> GetByIdAsync2(int id)
    {
        //Listing 11-14: Not required or used, just here to show alternative to GetByIdAsync from Listing 11-5
        return await _context.Set<T>().Where(x => x.Id == id).SingleOrDefaultAsync();
    }

    public async Task<T?> GetByNameAsync(string name)
    {
        //Listing 11-13
        var items = await _context.Set<T>().ToListAsync();
        return items.SingleOrDefault(e => e.FilterName == name);
    }

    public async Task<bool> AddAsync(T entity)
    {
        //Listing 11-15
        await _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        //Listing 11-16
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

    public async Task<bool> DeleteAsync(int id)
    {
        //Listing 11-17
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
        //Listing 11-18
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }
}
