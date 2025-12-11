using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF10_AWDBLibrary.Models;

/// <summary>
/// Products sold or used in the manfacturing of sold products.
/// </summary>
[Table("Product", Schema = "SalesLT")]
[Index("Name", Name = "AK_Product_Name", IsUnique = true)]
[Index("ProductNumber", Name = "AK_Product_ProductNumber", IsUnique = true)]
[Index("Rowguid", Name = "AK_Product_rowguid", IsUnique = true)]
public partial class Product
{
    /// <summary>
    /// Primary key for Product records.
    /// </summary>
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    /// <summary>
    /// Name of the product.
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Unique product identification number.
    /// </summary>
    [StringLength(25)]
    public string ProductNumber { get; set; } = null!;

    /// <summary>
    /// Product color.
    /// </summary>
    [StringLength(15)]
    public string? Color { get; set; }

    /// <summary>
    /// Standard cost of the product.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal StandardCost { get; set; }

    /// <summary>
    /// Selling price.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal ListPrice { get; set; }

    /// <summary>
    /// Product size.
    /// </summary>
    [StringLength(5)]
    public string? Size { get; set; }

    /// <summary>
    /// Product weight.
    /// </summary>
    [Column(TypeName = "decimal(8, 2)")]
    public decimal? Weight { get; set; }

    /// <summary>
    /// Product is a member of this product category. Foreign key to ProductCategory.ProductCategoryID. 
    /// </summary>
    [Column("ProductCategoryID")]
    public int? ProductCategoryId { get; set; }

    /// <summary>
    /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
    /// </summary>
    [Column("ProductModelID")]
    public int? ProductModelId { get; set; }

    /// <summary>
    /// Date the product was available for sale.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime SellStartDate { get; set; }

    /// <summary>
    /// Date the product was no longer available for sale.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? SellEndDate { get; set; }

    /// <summary>
    /// Date the product was discontinued.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? DiscontinuedDate { get; set; }

    /// <summary>
    /// Small image of the product.
    /// </summary>
    public byte[]? ThumbNailPhoto { get; set; }

    /// <summary>
    /// Small image file name.
    /// </summary>
    [StringLength(50)]
    public string? ThumbnailPhotoFileName { get; set; }

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

    [ForeignKey("ProductCategoryId")]
    [InverseProperty("Products")]
    public virtual ProductCategory? ProductCategory { get; set; }

    [ForeignKey("ProductModelId")]
    [InverseProperty("Products")]
    public virtual ProductModel? ProductModel { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
