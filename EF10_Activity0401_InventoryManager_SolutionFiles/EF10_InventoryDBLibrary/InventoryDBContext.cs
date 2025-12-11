using EF10_InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryDBLibrary;

public partial class InventoryDbContext : DbContext
{
    private const string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";

    public DbSet<Item> Items { get; set; }

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
        // Example: Set default value for IsActive
        // modelBuilder.Entity<Item>()
        //     .Property(i => i.IsActive)
        //     .HasDefaultValue(true);
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
