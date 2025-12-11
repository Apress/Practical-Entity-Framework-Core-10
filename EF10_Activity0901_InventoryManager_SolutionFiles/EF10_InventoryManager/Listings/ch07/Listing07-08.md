# Listing 7-8. Add the DbSet<ItemByGenreDTO> ItemsByGenre 

Find the correct place in the InventoryDbContext.cs file to place a new DBSet<T> property.

## The Code

Use this code to add the mapped `DbSet<ItemByGenreDTO> ItemsByGenre` under the code:
`public DbSet<ItemByCategoryDTO> ItemsByCategory { get; set; }`

```cs
//Added for Activity0702-Step4 [listing 7-6]
public DbSet<ItemByGenreDTO> ItemsByGenre { get; set; }
```  