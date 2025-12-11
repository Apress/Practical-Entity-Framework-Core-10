using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EF10_NewFeaturesModels;

[Index(nameof(ItemName), nameof(CategoryId), nameof(TenantId), IsUnique = true)]
public class Item : DefaultBaseModel
{
    [Required]
    public string ItemName { get; set; }
    [StringLength(200)]
    public string? Description { get; set; }
    public int CategoryId { get; set; }
    public int TenantId { get; set; }
    public bool IsOnSale { get; set; }
    public virtual Category? Category { get; set; }
    public virtual Tenant? Tenant { get; set; }
    public virtual List<ItemContributor>? ItemContributors { get; set; } = new List<ItemContributor>();
    public virtual List<Genre>? Genres { get; set; } = new List<Genre>();
}
