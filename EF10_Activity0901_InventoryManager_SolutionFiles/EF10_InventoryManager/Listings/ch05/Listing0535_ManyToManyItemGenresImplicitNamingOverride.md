# Listing 5-35 - Adding an entity definition for ItemGenres to override the implicit table naming.

Override the default implicit naming convention for the *many-to-many* join table between `Items` and `Genres` 
by specifying the table name as "ItemGenres" in the `OnModelCreating` method of the `InventoryDbContext` class. 
This ensures that the join table is named explicitly rather than relying on EF Core's default naming conventions.

## DBContext.OnModelCreating change

```cs  
//…existing code

//reference Listing0535_ManyToManyItemGenresImplicitNamingOverride.md  for full code
//new code:
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
            //note, there is no "Id" property in the implicit join table
            join.HasKey("ItemId", "GenreId");  
        });
});
```  

## Notes

Full code follows:  

```cs
using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF10_InventoryDBLibrary;

public partial class InventoryDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contributor> Contributors { get; set; }
    public DbSet<ItemContributor> ItemContributors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public InventoryDbContext()
    {
        
    }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasIndex(i => new { i.Name, i.CategoryId }).IsUnique();  //<-- change is right here

            entity.Property(i => i.Quantity)
                .IsRequired();

            entity.Property(i => i.Description)
                .HasMaxLength(500);

            entity.Property(i => i.Notes)
                .HasMaxLength(500);

            entity.Property(i => i.IsOnSale)
                .HasDefaultValue(false);

            entity.Property(i => i.IsActive)
                .HasDefaultValue(true);

            // New check constraint syntax (EF Core 8+)
            entity.ToTable(t =>
            {
                t.HasCheckConstraint("CK_Item_Quantity_NonNegative", "[Quantity] >= 0");
                t.HasCheckConstraint("CK_Item_PurchasePrice_NonNegative", "[PurchasePrice] IS NULL OR [PurchasePrice] >= 0");
                t.HasCheckConstraint("CK_Item_CurrentValue_NonNegative", "[CurrentValue] IS NULL OR [CurrentValue] >= 0");
            });

            // Many-to-many join table configuration for ItemGenres                   //<-- NEW CODE IS HERE 
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
                        //note, there is no "Id" property in the implicit join table
                        join.HasKey("ItemId", "GenreId");  
                    });                                                                 //<-- End of new
        });  

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasIndex(g => g.GenreName).IsUnique();
            entity.Property(g => g.IsActive)
                .HasDefaultValue(true);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(c => c.IsActive)
                .HasDefaultValue(true);
        });  

        modelBuilder.Entity<Contributor>(entity =>
        {
            entity.HasIndex(c => c.ContributorName).IsUnique();
            entity.Property(c => c.IsActive)
                .HasDefaultValue(true);
        });

        modelBuilder.Entity<ItemContributor>(entity =>
        {
            entity.HasIndex(ic => new { ic.ItemId, ic.ContributorId })
                .IsUnique();
            entity.Property(ic => ic.ContributorType)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();
        });
    }
}
```  
