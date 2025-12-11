# Listing 04-13: Add the code to create/modify the audit fields when SaveChangesAsync is called.  

Add the method below to the `InventoryDbContext`.cs class.

## Implement the SaveChangesAsync method 

Replace the foreach loop in the override with the following code:

```cs
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
```  

## The Full Method

For Clarity, here is the full method:

```cs
public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
{
    var tracker = ChangeTracker;
    foreach (var entry in tracker.Entries())
    {
        System.Diagnostics.Debug.WriteLine($"{entry.Entity} has state {entry.State}");
    }
    return base.SaveChangesAsync(cancellationToken);
}
```  

