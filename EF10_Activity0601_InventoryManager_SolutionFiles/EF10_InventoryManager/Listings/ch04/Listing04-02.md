# Listing 04-02: The explicit constructor for the InventoryDbContext

This is the explicit constructor for the InventoryDbContext

## The code

The snippet as shown in the book:  

```cs
public InventoryDbContext(DbContextOptions<InventoryDbContext> options
    : base(options)
{
}
```  