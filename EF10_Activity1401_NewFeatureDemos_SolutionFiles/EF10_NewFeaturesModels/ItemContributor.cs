using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EF10_NewFeaturesModels;

[Index(nameof(ItemId), nameof(ContributorId), IsUnique = true)]
public class ItemContributor: DefaultBaseModel
{
    public int ItemId { get; set; }
    public virtual Item? Item { get; set; }
    public int ContributorId { get; set; }
    public virtual Contributor? Contributor { get; set; }
    public ContributorType? ContributorType { get; set; }
}
