# Listing 5-18 - The Genre entity

Create the Genre entity in the EF10_InventoryModels project.

## The code

```cs
public class Genre : ActivatableIdentityModel
{
    [Required]
    [StringLength(50)]
    public string GenreName { get; set; }
}
```  

