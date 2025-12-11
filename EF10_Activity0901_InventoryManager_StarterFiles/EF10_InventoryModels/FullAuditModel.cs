using EF10_InventoryModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EF10_InventoryModels;

public abstract class FullAuditModel : ActivatableIdentityModel, IAuditedModel
{
    [Required, StringLength(50)]
    public string CreatedByUserId { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [StringLength(50)]
    public string? LastModifiedUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
