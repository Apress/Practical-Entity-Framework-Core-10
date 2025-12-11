using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF10_NewFeaturesModels;

public class Genre : DefaultBaseModel
{
    [Required]
    [StringLength(50)]
    public string GenreName { get; set; }

    [NotMapped]
    public string FilterName => GenreName;

    //Implicitly map many-to-many to Items
    public virtual List<Item>? Items { get; set; }
}
