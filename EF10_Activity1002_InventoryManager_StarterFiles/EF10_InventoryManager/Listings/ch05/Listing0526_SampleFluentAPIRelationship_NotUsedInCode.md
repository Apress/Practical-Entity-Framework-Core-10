# Listing 5-26 - A Sample Fluent API defined Relationship

This listing shows how to define a one-to-many relationship using the Fluent API in the `OnModelCreating`
method of your `DbContext` class. This example assumes you have an `Item` class that has a foreign key to a `Category` class.

We are NOT doing this in the code, this is for illustration purposes only. 

## One Category to many Items defined in Fluent API

```cs  
modelBuilder.Entity<Item>()
        .HasOne(i => i.Category) // The Item has one Category
        .WithMany(c => c.Items) // The Category has Many Items
        .HasForeignKey(i => i.CategoryId); // Item has foreign key named CategoryId
```  

## Notes

This code is NOT intended to be implemented in the solution.  It exists for illustration purposes only.  
