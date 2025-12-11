using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF10_AWDBLibrary.Models;

/// <summary>
/// High-level product categorization.
/// </summary>
[Table("ProductCategory", Schema = "SalesLT")]
[Index("Name", Name = "AK_ProductCategory_Name", IsUnique = true)]
[Index("Rowguid", Name = "AK_ProductCategory_rowguid", IsUnique = true)]
public partial class ProductCategory
{
    /// <summary>
    /// Primary key for ProductCategory records.
    /// </summary>
    [Key]
    [Column("ProductCategoryID")]
    public int ProductCategoryId { get; set; }

    /// <summary>
    /// Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.
    /// </summary>
    [Column("ParentProductCategoryID")]
    public int? ParentProductCategoryId { get; set; }

    /// <summary>
    /// Category description.
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [InverseProperty("ParentProductCategory")]
    public virtual ICollection<ProductCategory> InverseParentProductCategory { get; set; } = new List<ProductCategory>();

    [ForeignKey("ParentProductCategoryId")]
    [InverseProperty("InverseParentProductCategory")]
    public virtual ProductCategory? ParentProductCategory { get; set; }

    [InverseProperty("ProductCategory")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
