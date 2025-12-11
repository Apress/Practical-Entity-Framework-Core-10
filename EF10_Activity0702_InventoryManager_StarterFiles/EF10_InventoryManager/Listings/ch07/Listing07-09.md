# Listing 7-9: Making sure the Procedure is not tracked and is marked as `HasNoKey`

In order to keep EF from trying to track the object as a Table and also making sure EF isn't looking for a key, use the Fluent API to define the entity.

## The Code to tell EF how to treat the new DTO object

Use this code at the bottom of the OnModelCreating method to make sure that the ItemByGenreDTO is not tracked and has no key:

```cs
//listing 7-9: ItemByGenreDTO mapping to view
modelBuilder.Entity<ItemByGenreDTO>(entity =>
{
    entity.HasNoKey(); // This is a DTO, not a tracked entity
    entity.ToView("ItemsByGenre");
});
```  