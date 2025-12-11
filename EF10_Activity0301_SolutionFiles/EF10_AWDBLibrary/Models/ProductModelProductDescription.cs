using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF10_AWDBLibrary.Models;

/// <summary>
/// Cross-reference table mapping product descriptions and the language the description is written in.
/// </summary>
[PrimaryKey("ProductModelId", "ProductDescriptionId", "Culture")]
[Table("ProductModelProductDescription", Schema = "SalesLT")]
[Index("Rowguid", Name = "AK_ProductModelProductDescription_rowguid", IsUnique = true)]
public partial class ProductModelProductDescription
{
    /// <summary>
    /// Primary key. Foreign key to ProductModel.ProductModelID.
    /// </summary>
    [Key]
    [Column("ProductModelID")]
    public int ProductModelId { get; set; }

    /// <summary>
    /// Primary key. Foreign key to ProductDescription.ProductDescriptionID.
    /// </summary>
    [Key]
    [Column("ProductDescriptionID")]
    public int ProductDescriptionId { get; set; }

    /// <summary>
    /// The culture for which the description is written
    /// </summary>
    [Key]
    [StringLength(6)]
    public string Culture { get; set; } = null!;

    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ProductDescriptionId")]
    [InverseProperty("ProductModelProductDescriptions")]
    public virtual ProductDescription ProductDescription { get; set; } = null!;

    [ForeignKey("ProductModelId")]
    [InverseProperty("ProductModelProductDescriptions")]
    public virtual ProductModel ProductModel { get; set; } = null!;
}
