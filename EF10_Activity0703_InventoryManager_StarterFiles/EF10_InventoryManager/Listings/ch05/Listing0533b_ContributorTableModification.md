# Listing 5-33b - Adding navigation to ItemContributors for Contributor class

Create the navigation property in the `Contributor` class to represent the many-to-many relationship between `Contributor` and `Item` 
through the `ItemContributor` join entity.

## Contributor

```cs  
//..existing code 

//new code
//explicitly define join to ItemContributor to create mapping to Items through ItemContributors 
//for the many-to-many relationship
public virtual List<ItemContributor>? ItemContributors { get; set; }
//Note: Full code available in Listing0533a_ItemTableModification.md &&
//           Listing0533b_ContributorTableModification.md
```  

## Notes

Full code follows:  

```cs
using System.ComponentModel.DataAnnotations;

namespace EF10_InventoryModels;

public class Contributor : ActivatableIdentityModel
{
    [Required, StringLength(50)]
    public string ContributorName { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }

    //explicitly define join to ItemContributor to create mapping to Items through ItemContributors 
    // for the many-to-many relationship
    public virtual List<ItemContributor>? ItemContributors { get; set; }
}
```  
