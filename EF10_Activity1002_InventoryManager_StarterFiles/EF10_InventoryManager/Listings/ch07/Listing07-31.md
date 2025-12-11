# Listing 7-31: Add the DTO as a DbSet

Add the `DbSet<ItemDetailSummaryDTO` to the `InventoryManagerDbContext`

## Code

Add the declaration to the top of the InventoryManagerDbContext along with the other DbSet declarations.  

```cs
public DbSet<ItemDetailSummaryDTO> ItemDetailSummaries { get; set; }
```  