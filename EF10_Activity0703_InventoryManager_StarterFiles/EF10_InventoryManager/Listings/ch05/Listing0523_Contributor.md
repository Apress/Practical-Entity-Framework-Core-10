# Listing 5-23 - Creating the Contributor class

Create a class called `Contributor` in the `EF10_InventoryModels` namespace.

## Contributor

```cs  
public class Contributor : ActivatableIdentityModel
{
    [Required, StringLength(100)]
    public string ContributorName { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }
}
```  

## Notes

Two fields: 
- ContributorName (you could rename to just `Name` if you want) - Required and limited to 50 chars
- Description (not required, limited to 250 chars - set a longer length if you want)

Through inheritance, Contributor will get an Id and IsActive field.  The IsActive field will need to be constrained in the OnModelCreating method (Listing 5-24), as will the default value for IsActive.
