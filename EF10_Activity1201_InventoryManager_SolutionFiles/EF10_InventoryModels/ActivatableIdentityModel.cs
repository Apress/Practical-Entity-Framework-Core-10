using EF10_InventoryModels.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF10_InventoryModels;

public abstract class ActivatableIdentityModel : INameFilterableModel, IIdentityModel, IActivatableModel
{
    [Required, Key]
    public int Id { get; set; }
    [Required, DefaultValue(true)]
    public bool IsActive { get; set; } = true;
    [NotMapped]
    public abstract string FilterName { get; }
    
}


