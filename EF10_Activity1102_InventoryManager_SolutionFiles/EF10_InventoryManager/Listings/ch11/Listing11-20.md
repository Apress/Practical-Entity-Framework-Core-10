# Listing 11-20: The listing for the Item repository

Change the declaration for the ItemRepository as follows

## The code

```cs
public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    private readonly InventoryDbContext _context;

    public ItemRepository(InventoryDbContext context)
        : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    //...other code - see Listing 11-21
}
```  
