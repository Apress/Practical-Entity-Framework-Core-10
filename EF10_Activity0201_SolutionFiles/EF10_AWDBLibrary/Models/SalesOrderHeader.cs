using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF10_AWDBLibrary.Models;

/// <summary>
/// General sales order information.
/// </summary>
[Table("SalesOrderHeader", Schema = "SalesLT")]
[Index("SalesOrderNumber", Name = "AK_SalesOrderHeader_SalesOrderNumber", IsUnique = true)]
[Index("Rowguid", Name = "AK_SalesOrderHeader_rowguid", IsUnique = true)]
[Index("CustomerId", Name = "IX_SalesOrderHeader_CustomerID")]
public partial class SalesOrderHeader
{
    /// <summary>
    /// Primary key.
    /// </summary>
    [Key]
    [Column("SalesOrderID")]
    public int SalesOrderId { get; set; }

    /// <summary>
    /// Incremental number to track changes to the sales order over time.
    /// </summary>
    public byte RevisionNumber { get; set; }

    /// <summary>
    /// Dates the sales order was created.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Date the order is due to the customer.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Date the order was shipped to the customer.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? ShipDate { get; set; }

    /// <summary>
    /// Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled
    /// </summary>
    public byte Status { get; set; }

    /// <summary>
    /// 0 = Order placed by sales person. 1 = Order placed online by customer.
    /// </summary>
    public bool OnlineOrderFlag { get; set; }

    /// <summary>
    /// Unique sales order identification number.
    /// </summary>
    [StringLength(25)]
    public string SalesOrderNumber { get; set; } = null!;

    /// <summary>
    /// Customer purchase order number reference. 
    /// </summary>
    [StringLength(25)]
    public string? PurchaseOrderNumber { get; set; }

    /// <summary>
    /// Financial accounting number reference.
    /// </summary>
    [StringLength(15)]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Customer identification number. Foreign key to Customer.CustomerID.
    /// </summary>
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    /// <summary>
    /// The ID of the location to send goods.  Foreign key to the Address table.
    /// </summary>
    [Column("ShipToAddressID")]
    public int? ShipToAddressId { get; set; }

    /// <summary>
    /// The ID of the location to send invoices.  Foreign key to the Address table.
    /// </summary>
    [Column("BillToAddressID")]
    public int? BillToAddressId { get; set; }

    /// <summary>
    /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
    /// </summary>
    [StringLength(50)]
    public string ShipMethod { get; set; } = null!;

    /// <summary>
    /// Approval code provided by the credit card company.
    /// </summary>
    [StringLength(15)]
    [Unicode(false)]
    public string? CreditCardApprovalCode { get; set; }

    /// <summary>
    /// Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal SubTotal { get; set; }

    /// <summary>
    /// Tax amount.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal TaxAmt { get; set; }

    /// <summary>
    /// Shipping cost.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal Freight { get; set; }

    /// <summary>
    /// Total due from customer. Computed as Subtotal + TaxAmt + Freight.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal TotalDue { get; set; }

    /// <summary>
    /// Sales representative comments.
    /// </summary>
    public string? Comment { get; set; }

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

    [ForeignKey("BillToAddressId")]
    [InverseProperty("SalesOrderHeaderBillToAddresses")]
    public virtual Address? BillToAddress { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("SalesOrderHeaders")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("SalesOrder")]
    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();

    [ForeignKey("ShipToAddressId")]
    [InverseProperty("SalesOrderHeaderShipToAddresses")]
    public virtual Address? ShipToAddress { get; set; }
}
