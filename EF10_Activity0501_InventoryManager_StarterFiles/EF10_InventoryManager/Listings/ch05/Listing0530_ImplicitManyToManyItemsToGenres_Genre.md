# Listing 5-30 - Creating the Navigation to Items in the Many to Many Items to Genres relationship Implicitly  

Create the navigation property in the `Genre` class to represent the *many-to-many* relationship between `Genre` and `Item`.

## Genre

```cs
public class Genre : ActivatableIdentityModel
{
    [Required]
    [StringLength(50)]
    public string GenreName { get; set; }

    //Implicitly map many-to-many to Items
    public virtual List<Item>? Items { get; set; }
}
```  

## Notes

Added the mapping ot Items as a nullable property to implicitly create the join.

Using nullable is critical to allow you to work in isolation on just a Genre object.