# Listing 11-7. Requiring Name Filter on all models for use in the system with a constraint

Creating a Name Filterable Model base

## The code

Update the `ActivatableIdentityModel` to the following code:

```cs
public abstract class ActivatableIdentityModel : IIdentityModel, IActivatableModel, INameFilterableModel
{
    [Required, Key]
    public int Id { get; set; }
    
    [Required, DefaultValue(true)]
    public bool IsActive { get; set; } = true;


    [NotMapped]
    public abstract string FilterName { get; }
}
```  

Make sure to note the field is not mapped, and it's readonly.