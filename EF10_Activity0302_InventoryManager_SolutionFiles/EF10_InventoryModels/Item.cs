using System.ComponentModel.DataAnnotations;

namespace EF10_InventoryModels;

public class Item
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }    

    /// <summary>
    /// Is Active indicates whether the item is active in the inventory.
    /// </summary>
    /// <note>commented out for completeness</note>
    //public bool IsActive { get; set; } = true;
}
