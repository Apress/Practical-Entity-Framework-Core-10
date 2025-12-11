using EF10_InventoryDBLibrary;
using EF10_InventoryModels;

namespace EF10_InventoryDataLayer;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly InventoryDbContext _context;

    public CategoryRepository(InventoryDbContext context)
        : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
