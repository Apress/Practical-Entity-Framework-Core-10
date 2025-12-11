using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF10_InventoryModels;

public class Item : FullAuditModel
{
    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, Range(0, int.MaxValue)] // Prevent negative quantities
    public int Quantity { get; set; }

    [StringLength(500)] // Set a reasonable max length for description
    public string? Description { get; set; }

    [StringLength(500)] // Set a reasonable max length for notes
    public string? Notes { get; set; }

    [DefaultValue(false)] // Default value for IsOnSale
    public bool IsOnSale { get; set; } = false;

    public DateTime? PurchasedDate { get; set; }
    public DateTime? SoldDate { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? PurchasePrice { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? CurrentValue { get; set; }

    //PII Number added for chapter 10 demonstration
    //will not be in any other chapter examples
    public byte[]? PIINumber { get; set; }

    //removed in Activity 1001 Task 6 for cleanup, left here for reference
    //[StringLength(50)]
    //public string? PIINumberBackup { get; set; }

    //An item is mapped to a single category
    [Required]
    public virtual int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    //Implicitly map many-to-many to Genres
    public virtual List<Genre>? Genres { get; set; }

    //explicitly define join to ItemContributor to create mapping to Contributors through ItemContributors 
    //for the many-to-many relationship
    public virtual List<ItemContributor>? ItemContributors { get; set; }

}

