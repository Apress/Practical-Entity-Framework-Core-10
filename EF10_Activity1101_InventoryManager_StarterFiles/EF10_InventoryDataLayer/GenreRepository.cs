using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EF10_InventoryDataLayer;

public class GenreRepository : IGenreRepository
{
    private readonly InventoryDbContext _context;
    
    public GenreRepository(InventoryDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Genre?> GetGenreByIdAsync(int id)
    {
        return await _context.Genres.SingleOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Genre?> GetGenreByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be null or empty");
        }
        
        var genre = await _context.Genres.SingleOrDefaultAsync(g => g.GenreName.ToLower() == name.ToLower());
        return genre;
    }

    public async Task<List<Genre>> GetAllGenresAsync()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<Genre> AddOrUpdateGenreAsync(Genre genre)
    {
        if (genre == null)
        {
            throw new ArgumentNullException(nameof(genre));
        }
        if (genre.Id > 0)
        {
            // Update existing genre
            return await Update(genre);
        }
        return await Add(genre);
    }

    private async Task<Genre> Add(Genre genre)
    {
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
        return genre;
    }

    private async Task<Genre> Update(Genre genre)
    {
        var existingGenre = await _context.Genres.FindAsync(genre.Id);
        if (existingGenre == null)
        {
            throw new KeyNotFoundException($"Genre with ID {genre.Id} not found");
        }
        
        // Update properties
        existingGenre.GenreName = genre.GenreName;
        existingGenre.IsActive = genre.IsActive;

        await _context.SaveChangesAsync();
        return existingGenre;
    }

    public async Task<Genre> DeleteGenreAsync(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre == null)
        {
            throw new KeyNotFoundException($"Genre with ID {id} not found.");
        }
        
        _context.Genres.Remove(genre);
        var result = await _context.SaveChangesAsync();
        return genre; 
    }

    public async Task<List<Genre>> FindGenresAsync(Expression<Func<Genre, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        
        return await _context.Genres.Where(predicate).ToListAsync();
    }
}
