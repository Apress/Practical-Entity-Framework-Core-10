# Listing 5-38. Seed Genre Data in the InventoryDbContext

Create the initial set of `Genre` data in the `OnModelCreating` method of the `InventoryDbContext` class using the `HasData` method. 
This seeds the database with predefined categories when the database is created or migrated.

## Change to DBContext.OnModelCreating  

```cs
modelBuilder.Entity<Genre>(entity =>
{
    entity.HasIndex(g => g.GenreName).IsUnique();
    entity.Property(g => g.IsActive)
        .HasDefaultValue(true);
    entity.HasData(
        SeedData.Genres
    );
});
```

## Full Code for ALL seeding

```cs

```  