using EF10_InventoryDBLibrary;
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryDataLayer;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    private readonly InventoryDbContext _context;
    
    public GenreRepository(InventoryDbContext context)
        : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
