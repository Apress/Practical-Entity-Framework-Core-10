using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EF10_NewFeaturesModels;

[Index(nameof(CategoryName), IsUnique = true)]
public class Category : DefaultBaseModel
{
    [Required]
    [StringLength(50)]
    public string CategoryName { get; set; }

    [StringLength(200)]
    public string? Description { get; set; }

    public virtual List<Item> Items { get; set; } = new List<Item>();
}
