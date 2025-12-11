using EF10_InventoryDBLibrary.Seeding;
using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryDBLibrary;

public partial class InventoryDbContext : DbContext
{
    private const string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";

    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contributor> Contributors { get; set; }
    public DbSet<ItemContributor> ItemContributors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    //added prior to Activity 0701 to support the DTOs for stored procedures and views
    public DbSet<ContributorSummaryDTO> ContributorSummaries { get; set; }
    //added prior to Activity 0701 to support the DTOs for stored procedures and views
    public DbSet<ItemByCategoryDTO> ItemsByCategory { get; set; }

    //add additional DbSets for DTOs here as needed:
    //item by genre [listing 7-8]
    public DbSet<ItemByGenreDTO> ItemsByGenre { get; set; }

    //listing 7-23 - for fnItemsWithCsvDetails
    public DbSet<ItemWithCsvDetailsDTO> ItemsWithCsvDetails { get; set; }

    //listing 7-31 - for vwItemsWithGenresAndContributors => ItemDetailSummaryDTO
    public DbSet<ItemDetailSummaryDTO> ItemDetailSummaries { get; set; }

    public InventoryDbContext()
    {
        //enable or disable lazy loading 
        //ChangeTracker.LazyLoadingEnabled = false; 

        //set the default tracking behavior for the context
        //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
        //enable or disable lazy loading 
        //ChangeTracker.LazyLoadingEnabled = false; 

        //set the default tracking behavior for the context
        //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
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

                        //seed table data for join to Genres
                        join.HasData(
                            SeedData.ItemGenres
                        );
                    });

            entity.HasData(
                SeedData.Items
            );

        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasIndex(g => g.GenreName).IsUnique();
            entity.Property(g => g.IsActive)
                .HasDefaultValue(true);
            entity.HasData(
                SeedData.Genres
            );
        });


        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(c => c.IsActive)
                .HasDefaultValue(true);
            entity.HasData(
                SeedData.Categories
            );
        });

        modelBuilder.Entity<Contributor>(entity =>
        {
            entity.Property(c => c.ContributorName)
                .IsRequired()
                .HasMaxLength(100);
            entity.HasIndex(c => c.ContributorName).IsUnique();
            entity.Property(c => c.IsActive)
                .HasDefaultValue(true);
            entity.HasData(
                SeedData.Contributors
            );
        });

        modelBuilder.Entity<ItemContributor>(entity =>
        {
            entity.HasIndex(ic => new { ic.ItemId, ic.ContributorId })
                .IsUnique();
            entity.Property(ic => ic.ContributorType)
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();
            entity.HasData(
                SeedData.ItemContributors
            );
        });


        //added prior to Activity 0701 to support the DTOs for stored procedures and views
        modelBuilder.Entity<ContributorSummaryDTO>()
            .HasNoKey()
            .ToView("vwContributorsItems");


        //added prior to Activity 0701 to support the DTOs for stored procedures and views
        modelBuilder.Entity<ItemByCategoryDTO>(entity =>
        {
            entity.HasNoKey(); // This is a DTO, not a tracked entity
            entity.ToView("ItemsByCategory");
        });

        //listing 7-9: ItemByGenreDTO mapping to view
        modelBuilder.Entity<ItemByGenreDTO>(entity =>
        {
            entity.HasNoKey(); // This is a DTO, not a tracked entity
            entity.ToView("ItemsByGenre");
        });

        //listing 7-24
        modelBuilder.Entity<ItemWithCsvDetailsDTO>(entity =>
        {
            entity.HasNoKey();
            entity.ToView(null); // No actual view; TVF is mapped via FromSqlRaw
        });

        //listing 7-32
        modelBuilder
            .Entity<ItemDetailSummaryDTO>()
            .HasNoKey()
            .ToView("vwItemsWithGenresAndContributors");

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var tracker = ChangeTracker;
        foreach (var entry in tracker.Entries())
        {
            if (entry.Entity is FullAuditModel)
            {
                var referenceEntity = entry.Entity as FullAuditModel;
                if (referenceEntity is null) continue;
                switch (entry.State)
                {
                    case EntityState.Added:
                        referenceEntity.CreatedDate = DateTime.Now;
                        if (string.IsNullOrWhiteSpace(referenceEntity.CreatedByUserId))
                        {
                            referenceEntity.CreatedByUserId = _systemUserId;
                        }
                        break;
                    case EntityState.Deleted:
                    case EntityState.Modified:
                        referenceEntity.LastModifiedDate = DateTime.Now;
                        if (string.IsNullOrWhiteSpace(referenceEntity.LastModifiedUserId))
                        {
                            referenceEntity.LastModifiedUserId = _systemUserId;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }


}
