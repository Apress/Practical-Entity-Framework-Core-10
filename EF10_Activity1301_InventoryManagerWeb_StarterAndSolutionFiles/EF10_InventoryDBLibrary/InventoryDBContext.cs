using EF10_InventoryDBLibrary.Seeding;
using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF10_InventoryDBLibrary;

public partial class InventoryDbContext : DbContext
{
    private const string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";
    private static readonly DateTime _seedItemCreatedDate = new DateTime(2025, 11, 1);
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
    //Added for Activity0701-Step4
    public DbSet<ItemByGenreDTO> ItemsByGenre { get; set; }

    //Added for Activity 0702 - Task 2 - Step 4 
    public DbSet<ItemWithCsvDetailsDTO> ItemsWithCsvDetails { get; set; }

    //Added for Activity 0703 - Step 4
    public DbSet<ItemDetailSummaryDTO> ItemDetailSummaries { get; set; }  

    public InventoryDbContext()
    {
        Configure();
    }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
        Configure();
    }

    private void Configure()
    {
        // Set the default tracking behavior for the context
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll; // Default behavior, can be changed as needed
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

            entity.HasIndex(i => new { i.Name, i.CategoryId }).IsUnique();

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
                        join.HasKey("ItemId", "GenreId");

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

        //Added for Activity0701-Step4
        modelBuilder.Entity<ItemByGenreDTO>(entity =>
        {
            entity.HasNoKey(); // This is a DTO, not a tracked entity
            entity.ToView("ItemsByGenre");
        });

        //Added for Activity 0702 - Task 2 - Step 4
        modelBuilder.Entity<ItemWithCsvDetailsDTO>(entity =>
        {
            entity.HasNoKey();
            entity.ToView(null); // No actual view; TVF is mapped via FromSqlRaw
        });

        //Added for Activity 0703 - Step 4
        modelBuilder
            .Entity<ItemDetailSummaryDTO>()
            .HasNoKey()
            .ToView("vwItemsWithGenresAndContributors");

    }

    /// <summary>
    /// Override the SaveChangesAsync method to add automated auditing
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
