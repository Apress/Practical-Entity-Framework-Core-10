using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

public interface IGenreRepository 
{
    Task<Genre?> GetGenreByIdAsync(int id);
    Task<Genre?> GetGenreByNameAsync(string name);
    Task<List<Genre>> GetAllGenresAsync();
    Task<Genre> AddOrUpdateGenreAsync(Genre genre);
    Task<Genre> DeleteGenreAsync(int id);
    Task<List<Genre>> FindGenresAsync(Expression<Func<Genre, bool>> predicate);
}
