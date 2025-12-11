using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryServiceLayer;

public interface IGenreService
{
    Task<Genre?> GetGenreByIdAsync(int id);
    Task<Genre?> GetGenreByNameAsync(string name);
    Task<List<Genre>> GetAllGenresAsync();
    Task<Genre> AddGenreAsync(Genre genre);
    Task<Genre> UpdateGenreAsync(Genre genre);
    Task<Genre> DeleteGenreAsync(int id);
    Task<List<Genre>> FindGenresAsync(Expression<Func<Genre, bool>> predicate);
}
