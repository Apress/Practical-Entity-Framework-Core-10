using System.ComponentModel.DataAnnotations;

namespace EF10_InventoryModels;

public class Genre : ActivatableIdentityModel
{
    [Required]
    [StringLength(50)]
    public string GenreName { get; set; }

    //Implicitly map many-to-many to Items
    public virtual List<Item>? Items { get; set; }
}
