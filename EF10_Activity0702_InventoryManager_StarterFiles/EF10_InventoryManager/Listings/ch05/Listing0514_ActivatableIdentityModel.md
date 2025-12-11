# Listing 5-14 - The Base ActivatableIdentityModel

## ActivatableIdentityModel

```cs
public abstract class ActivatableIdentityModel : IIdentityModel, IActivatableModel
{
    [Required, Key]
    public int Id { get; set; }
    
    [Required, DefaultValue(true)]
    public bool IsActive { get; set; } = true;
}
```  

## Notes

Create as a new class in the InventoryDbModels project.  Take note of the values.  Remember that IsActive will need to be set in the Fluent API for concrete classes.