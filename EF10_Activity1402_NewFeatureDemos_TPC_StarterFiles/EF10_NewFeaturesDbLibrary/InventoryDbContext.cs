using EF10_NewFeaturesDbLibrary.Seeding;
using EF10_NewFeaturesModels;
using EF10_NewFeaturesModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF10_NewFeaturesDbLibrary;    

public partial class InventoryDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contributor> Contributors { get; set; }
    public DbSet<ItemContributor> ItemContributors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<JunkToBulkDelete> JunkToBulkDeletes { get; set; }

    public DbSet<Book> Books { get; set; }
    public DbSet<Movie> Movies { get; set; }

    private LoggingCommandInterceptor _loggingInterceptor;
    private SoftDeleteInterceptor _softDeleteInterceptor;

    public InventoryDbContext()
        : base()
    {
        Configure();
    }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options
                                , LoggingCommandInterceptor loggingInterceptor
                                , SoftDeleteInterceptor softDeleteInterceptor)
        : base(options)
    {
        Configure();
        _loggingInterceptor = loggingInterceptor;
        _softDeleteInterceptor = softDeleteInterceptor;
    }

    private void Configure()
    {
        // Set the default tracking behavior for the context
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Load configuration from appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("InventoryDbConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        base.OnModelCreating(modelBuilder);

        //*********************************************************************
        //TODO: Add Filters here (soft delete, multi-tenant, Active, etc.)
        modelBuilder.Entity<Category>()
                        .HasQueryFilter("SoftDelete", c => !c.IsDeleted)
                        .HasQueryFilter("Active", c => c.IsActive);

        modelBuilder.Entity<Contributor>()
                        .HasQueryFilter("SoftDelete", c => !c.IsDeleted)
                        .HasQueryFilter("Active", c => c.IsActive);

        modelBuilder.Entity<Genre>()
                        .HasQueryFilter("SoftDelete", g => !g.IsDeleted)
                        .HasQueryFilter("Active", c => c.IsActive);

        modelBuilder.Entity<JunkToBulkDelete>()
                        .HasQueryFilter("SoftDelete", j => !j.IsDeleted)
                        .HasQueryFilter("Active", c => c.IsActive);

        modelBuilder.Entity<ItemContributor>()
                        .HasQueryFilter("SoftDelete", ic => !ic.IsDeleted)
                        .HasQueryFilter("Active", c => c.IsActive);

        modelBuilder.Entity<Item>()
                        .HasQueryFilter("SoftDelete", i => !i.IsDeleted)
                        .HasQueryFilter("Active", c => c.IsActive)
                        .HasQueryFilter("Tenant", i => i.TenantId == 1);

        //**********************************************************************
        //Note: In the real world, you would log in and that would set the TenantId for the user
        //and you would use a "CurrentUserService" or similar to get the current user's TenantId
        //**********************************************************************
        //entity configurations and seed data follow


        /** ADDED FOR TPC INHERITANCE **/
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(b => b.Id).UseIdentityColumn();
            entity.HasData(SeedData.Books);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.Property(m => m.Id).UseIdentityColumn();
            entity.HasData(SeedData.Movies);
        });
        /** END ADDED FOR TPC INHERITANCE **/

        modelBuilder.Entity<Item>(entity => {
            entity.Property(i => i.ItemName).IsRequired().HasMaxLength(100);
            entity.HasIndex(i => new { i.ItemName, i.CategoryId, i.TenantId }).IsUnique();
            entity.Property(i => i.IsOnSale)
                .HasDefaultValue(false); //FOR TPC, had to remove default constraint name here
            entity.Property(i => i.IsActive)
                .HasDefaultValue(true); //FOR TPC, had to remove default constraint name here
            //With listing 14-19, the default value constraints above were named.

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

            entity.HasData(SeedData.Items);

            //added for TPC inheritance:
            entity.Property(i => i.Id).UseIdentityColumn();
            entity.UseTpcMappingStrategy();
        });

        modelBuilder.Entity<Category>(entity => {
            entity.Property(c => c.CategoryName).IsRequired().HasMaxLength(50);
            entity.HasIndex(c => c.CategoryName).IsUnique();
            entity.Property(c => c.IsActive)
                .HasDefaultValue(true);

            entity.HasData(SeedData.Categories);
        });

        modelBuilder.Entity<Contributor>(entity => {
            entity.Property(c => c.ContributorName).IsRequired().HasMaxLength(50);
            entity.HasIndex(c => c.ContributorName).IsUnique();
            entity.Property(c => c.IsActive)
                .HasDefaultValue(true);
            entity.OwnsOne(a => a.Address, a =>
            {
                a.ToJson();
            });
        });

        modelBuilder.Entity<ItemContributor>(entity => {
            entity.HasKey(ic => new { ic.Id });
            entity.HasOne(ic => ic.Item)
                .WithMany(i => i.ItemContributors)
                .HasForeignKey(ic => ic.ItemId);
            entity.HasOne(ic => ic.Contributor)
                .WithMany(c => c.ContributorItems)
                .HasForeignKey(ic => ic.ContributorId);

            entity.HasData(SeedData.ItemContributors);
        });

        modelBuilder.Entity<Tenant>(entity => {
            entity.Property(t => t.TenantName).IsRequired().HasMaxLength(100);
            entity.HasIndex(t => t.TenantName).IsUnique();
            entity.Property(t => t.IsActive)
                .HasDefaultValue(true);
            entity.HasData(SeedData.Tenants);
        });

        modelBuilder.Entity<Genre>(entity => {
            entity.Property(g => g.GenreName).IsRequired().HasMaxLength(50);
            entity.HasIndex(g => g.GenreName).IsUnique();
            entity.Property(g => g.IsActive)
                .HasDefaultValue(true);

            entity.HasData(SeedData.Genres);
        });

        modelBuilder.Entity<JunkToBulkDelete>(entity =>
        {
            entity.Property(j => j.Name).IsRequired().HasMaxLength(100);
            entity.Property(j => j.IsActive)
                .HasDefaultValue(true);
            entity.Property(j => j.IsDeleted)
                .HasDefaultValue(false);
        });

        

    }
}
