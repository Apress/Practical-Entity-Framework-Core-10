using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF10_InventoryModels;

public class Genre : ActivatableIdentityModel
{
    [Required]
    [StringLength(50)]
    public string GenreName { get; set; }

    //Listing 11-10
    [NotMapped]
    public override string FilterName => GenreName;

    //Implicitly map many-to-many to Items
    public virtual List<Item>? Items { get; set; }
}
