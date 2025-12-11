using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EF10_InventoryModels;

[Index(nameof(CategoryName), IsUnique = true)]
public class Category : ActivatableIdentityModel
{
    [Required, StringLength(50)]
    public string CategoryName { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }

    public virtual List<Item>? Items { get; set; }
}
