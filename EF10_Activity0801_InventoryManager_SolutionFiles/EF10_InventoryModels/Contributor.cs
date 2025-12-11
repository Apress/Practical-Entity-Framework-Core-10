using System.ComponentModel.DataAnnotations;

namespace EF10_InventoryModels;

public class Contributor : ActivatableIdentityModel
{
    [Required, StringLength(100)]
    public string ContributorName { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }

    //explicitly define join to ItemContributor to create mapping to Items through ItemContributors 
    //for the many-to-many relationship
    public virtual List<ItemContributor>? ItemContributors { get; set; }
}
