# Listing 5-31 - Creating the ItemContributor class to explicitly define a join table

Create the `ItemContributor` class to explicitly define the join table for the many-to-many relationship between `Item` and `Contributor`.
Create in a new file named `ItemContributor.cs` in the `EF10_InventoryModels` project.

## ItemContributor

```cs  
public class ItemContributor : IIdentityModel
{
    [Required, Key]
    public int Id { get; set; }

    [Required]
    public int ItemId { get; set; }
    public virtual Item? Item { get; set; }

    [Required]
    public int ContributorId { get; set; }
    public virtual Contributor? Contributor { get; set; }

    [Required]
    public ContributorType ContributorType { get; set; }
}
```  

## Notes

The Key annotation is likely not required here, but I've included it since some conventions state that join tables don't typically have a single Id, rather they use a composite key for the two foreign keys.

Of course this means that a Fluent API entity constraint needs to be added (Listing 5-32) to prevent duplicate records with the same ItemId and ContributorId.  

Reminder: The navigation properties are not actually stored in the databse, so this will be a table with three columns of integer ids, followed by a column for the contributor type.

Since ContributorType is an enum, you'll also use Fluent API to force string conversion on the value for storing a more human-readable version (otherwise you'd have four columns of just integer Ids).  
