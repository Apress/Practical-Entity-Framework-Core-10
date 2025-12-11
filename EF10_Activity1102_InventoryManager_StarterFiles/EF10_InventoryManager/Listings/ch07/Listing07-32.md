# Listing 7-32: Make sure the view is not tracked

Add the typical Fluent API code to make sure the view is not tracked.

## code

Use this code at the end of the `OnModelCreating` method.

```cs
modelBuilder
    .Entity<ItemDetailSummaryDTO>()
    .HasNoKey()
    .ToView("vwItemsWithGenresAndContributors");
```  