# Listing 04-12: Overriding SaveChangesAsync to implement custom logic on save

Add the method below to the `InventoryDbContext`.cs class.

## Implement the SaveChangesAsync method 

Add the code into the `InventoryDbContext` at the bottom of the class.

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