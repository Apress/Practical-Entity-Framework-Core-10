using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryModels;

[Index(nameof(CategoryName), IsUnique = true)]
public class Category : ActivatableIdentityModel
{
    [Required, StringLength(50)]
    public string CategoryName { get; set; }

    //Listing 11-9
    [NotMapped]
    public override string FilterName => CategoryName;


    [StringLength(250)]
    public string? Description { get; set; }

    public virtual List<Item>? Items { get; set; }
}
