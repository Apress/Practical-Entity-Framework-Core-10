using EF10_InventoryModels.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF10_InventoryModels;

public abstract class ActivatableIdentityModel : IIdentityModel, IActivatableModel
{
    [Required, Key]
    public int Id { get; set; }

    [Required, DefaultValue(true)]
    public bool IsActive { get; set; } = true;
}
