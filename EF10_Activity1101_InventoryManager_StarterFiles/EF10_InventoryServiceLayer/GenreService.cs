using EF10_InventoryDataLayer;
using EF10_InventoryModels;
using System.Linq.Expressions;

namespace EF10_InventoryServiceLayer;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
    }

    public async Task<Genre?> GetGenreByIdAsync(int id)
    {
        return await _genreRepository.GetGenreByIdAsync(id);
    }
    public async Task<Genre?> GetGenreByNameAsync(string name)
    {
        return await _genreRepository.GetGenreByNameAsync(name);
    }
    public async Task<List<Genre>> GetAllGenresAsync()
    {
        return await _genreRepository.GetAllGenresAsync();
    }
    public async Task<Genre> AddGenreAsync(Genre genre)
    {
        return await _genreRepository.AddOrUpdateGenreAsync(genre);
    }

    public async Task<Genre> UpdateGenreAsync(Genre genre)
    {
        return await _genreRepository.AddOrUpdateGenreAsync(genre);
    }

    public async Task<Genre> DeleteGenreAsync(int id)
    {
        return await _genreRepository.DeleteGenreAsync(id);
    }

    public async Task<List<Genre>> FindGenresAsync(Expression<Func<Genre, bool>> predicate)
    {
        return await _genreRepository.FindGenresAsync(predicate);
    }
}
