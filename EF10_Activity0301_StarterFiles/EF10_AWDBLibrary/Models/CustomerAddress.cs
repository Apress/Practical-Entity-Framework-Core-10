using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF10_AWDBLibrary.Models;

/// <summary>
/// Cross-reference table mapping customers to their address(es).
/// </summary>
[PrimaryKey("CustomerId", "AddressId")]
[Table("CustomerAddress", Schema = "SalesLT")]
[Index("Rowguid", Name = "AK_CustomerAddress_rowguid", IsUnique = true)]
public partial class CustomerAddress
{
    /// <summary>
    /// Primary key. Foreign key to Customer.CustomerID.
    /// </summary>
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    /// <summary>
    /// Primary key. Foreign key to Address.AddressID.
    /// </summary>
    [Key]
    [Column("AddressID")]
    public int AddressId { get; set; }

    /// <summary>
    /// The kind of Address. One of: Archive, Billing, Home, Main Office, Primary, Shipping
    /// </summary>
    [StringLength(50)]
    public string AddressType { get; set; } = null!;

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

    [ForeignKey("AddressId")]
    [InverseProperty("CustomerAddresses")]
    public virtual Address Address { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("CustomerAddresses")]
    public virtual Customer Customer { get; set; } = null!;
}
