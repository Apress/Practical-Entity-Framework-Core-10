using EF10_InventoryModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EF10_InventoryModels;

public class ItemContributor : IIdentityModel
{
    [Required, Key]
    public int Id { get; set; }

    [Required]
    public int ItemId { get; set; }
    public virtual Item? Item { get; set; }

    [Required]
    public int ContributorId { get; set; }
    public virtual Contributor? Contributor { get; set; }

    [Required]
    public ContributorType ContributorType { get; set; }
}
