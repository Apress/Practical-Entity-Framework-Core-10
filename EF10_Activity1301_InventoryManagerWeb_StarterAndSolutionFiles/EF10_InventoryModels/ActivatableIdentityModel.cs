using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EF10_InventoryModels.Interfaces;  

namespace EF10_InventoryModels;

public abstract class ActivatableIdentityModel : IIdentityModel, IActivatableModel, INameFilterableModel
{
    [Required, Key]
    public int Id { get; set; }
    
    [Required, DefaultValue(true)]
    public bool IsActive { get; set; } = true;


    [NotMapped]
    public abstract string FilterName { get; }
}