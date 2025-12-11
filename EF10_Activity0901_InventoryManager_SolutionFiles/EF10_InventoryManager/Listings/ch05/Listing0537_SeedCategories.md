# Listing 5-37. Seed Category Data in the InventoryDbContext

Create the initial set of `Category` data in the `OnModelCreating` method of the `InventoryDbContext` class using the `HasData` method. 
This seeds the database with predefined categories when the database is created or migrated.

## Change to DBContext.OnModelCreating  

```cs
modelBuilder.Entity<Category>(entity =>
{
    entity.Property(c => c.IsActive)
        .HasDefaultValue(true);
    entity.HasData(
        SeedData.Categories
    );
});
```
 