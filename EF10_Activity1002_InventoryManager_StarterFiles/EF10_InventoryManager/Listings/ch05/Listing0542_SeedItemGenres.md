# Listing 5-42 Seed Item Genre Data in the InventoryDbContext

Create the initial set of `Item Genre` data in the `OnModelCreating` method of the `InventoryDbContext` class using the `HasData` method. 
This seeds the database with predefined categories when the database is created or migrated.

## Change to DBContext.OnModelCreating  

```cs
modelBuilder.Entity<Item>(entity =>
{
       //lots of other code

       // Many-to-many join table configuration for ItemGenres
        entity.HasMany(i => i.Genres)
            .WithMany(g => g.Items)
            .UsingEntity<Dictionary<string, object>>(
                "ItemGenres", //table name here
                right => right
                    .HasOne<Genre>()
                    .WithMany()
                    .HasForeignKey("GenreId")
                    .OnDelete(DeleteBehavior.Cascade),
                left => left
                    .HasOne<Item>()
                    .WithMany()
                    .HasForeignKey("ItemId")
                    .OnDelete(DeleteBehavior.Cascade),
                join =>
                {
                    join.HasKey("ItemId", "GenreId");

                    join.HasData(
                        SeedData.ItemGenres
                    );
                });

});
```
