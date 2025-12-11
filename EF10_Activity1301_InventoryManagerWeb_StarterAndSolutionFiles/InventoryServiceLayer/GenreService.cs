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
        return await _genreRepository.GetByIdAsync(id);
    }
    public async Task<Genre?> GetGenreByNameAsync(string name)
    {
        return await _genreRepository.GetByNameAsync(name);
    }
    public async Task<List<Genre>> GetAllGenresAsync()
    {
        return await _genreRepository.GetAllAsync();
    }
    public async Task<Genre> AddGenreAsync(Genre genre)
    {
        var success = await _genreRepository.AddAsync(genre);
        if (!success)
        {
            throw new InvalidOperationException("Failed to add the genre.");
        }
        var genreResult = await _genreRepository.GetByNameAsync(genre.GenreName);
        return genreResult ?? throw new InvalidOperationException("Genre not found after addition.");
    }

    public async Task<Genre> UpdateGenreAsync(Genre genre)
    {
        var success = await _genreRepository.UpdateAsync(genre);
        if (!success)
        {
            throw new InvalidOperationException("Failed to update the genre.");
        }
        var genreResult = await _genreRepository.GetByIdAsync(genre.Id);
        return genreResult ?? throw new InvalidOperationException("Genre not found after update.");
    }

    public async Task<Genre> DeleteGenreAsync(int id)
    {
        var genre = await _genreRepository.GetByIdAsync(id);
        if (genre == null)
        {
            throw new KeyNotFoundException($"Genre with ID {id} not found.");
        }
        var success =  await _genreRepository.DeleteAsync(id);
        if (!success)
        {
            throw new InvalidOperationException("Failed to delete the genre.");
        }
        return genre;
    }

    public async Task<List<Genre>> FindGenresAsync(Expression<Func<Genre, bool>> predicate)
    {
        return await _genreRepository.FindAsync(predicate);
    }
}
