# Listing 7-24. Keep the DTO from being tracked

Use the code to ensure that the new DTO is not tracked as a table entity by EF.

## The code

Add the following code into the `OnModelCreating` method

```cs
modelBuilder.Entity<ItemWithCsvDetailsDTO>(entity =>
{
    entity.HasNoKey();
    entity.ToView(null); // No actual view; TVF is mapped via FromSqlRaw
});
```  