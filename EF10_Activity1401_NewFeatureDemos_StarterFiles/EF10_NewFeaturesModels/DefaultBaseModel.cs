using EF10_NewFeaturesModels.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF10_NewFeaturesModels;

public abstract class DefaultBaseModel : ISoftDeletableModel, IActivatableModel, IIdentityModel
{
    [Key, Required]
    public int Id { get; set; }

    [Required, DefaultValue(false)]
    public bool IsDeleted { get; set; } = false;
    
    [Required, DefaultValue(true)]
    public bool IsActive { get; set; } = true;
}
