using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EF10_NewFeaturesModels;

[Index(nameof(ContributorName), IsUnique = true)]
public class Contributor: DefaultBaseModel
{
    [Required]
    [StringLength(50)]
    public string ContributorName { get; set; }

    public virtual List<ItemContributor> ContributorItems { get; set; } = new List<ItemContributor>();

    //Added for Listing 14-12 to work with Owned Entity Types (JSON columns)
    public Address? Address { get; set; } = null;
}
