using System;
using System.Collections.Generic;
using EF10_AWDBLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EF10_AWDBLibrary;

public partial class AdventureWorksContext : DbContext
{
    public AdventureWorksContext()
    {
    }

    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BuildVersion> BuildVersions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }

    public virtual DbSet<ProductModel> ProductModels { get; set; }

    public virtual DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

    public virtual DbSet<VGetAllCategory> VGetAllCategories { get; set; }

    public virtual DbSet<VProductAndDescription> VProductAndDescriptions { get; set; }

    public virtual DbSet<VProductModelCatalogDescription> VProductModelCatalogDescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=AWDbConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Address_AddressID");

            entity.ToTable("Address", "SalesLT", tb => tb.HasComment("Street address information for customers."));

            entity.Property(e => e.AddressId).HasComment("Primary key for Address records.");
            entity.Property(e => e.AddressLine1).HasComment("First street address line.");
            entity.Property(e => e.AddressLine2).HasComment("Second street address line.");
            entity.Property(e => e.City).HasComment("Name of the city.");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_Address_ModifiedDate");
            entity.Property(e => e.PostalCode).HasComment("Postal code for the street address.");
            entity.Property(e => e.Rowguid)
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasDefaultValueSql("(newid())", "DF_Address_rowguid");
            entity.Property(e => e.StateProvince).HasComment("Name of state or province.");
        });

        modelBuilder.Entity<BuildVersion>(entity =>
        {
            entity.ToTable("BuildVersion", tb => tb.HasComment("Current version number of the AdventureWorksLT 2012 sample database. "));

            entity.Property(e => e.DatabaseVersion).HasComment("Version number of the database in 9.yy.mm.dd.00 format.");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_BuildVersion_ModifiedDate");
            entity.Property(e => e.SystemInformationId)
                .ValueGeneratedOnAdd()
                .HasComment("Primary key for BuildVersion records.");
            entity.Property(e => e.VersionDate).HasComment("Date and time the record was last updated.");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_Customer_CustomerID");

            entity.ToTable("Customer", "SalesLT", tb => tb.HasComment("Customer information."));

            entity.Property(e => e.CustomerId).HasComment("Primary key for Customer records.");
            entity.Property(e => e.CompanyName).HasComment("The customer's organization.");
            entity.Property(e => e.EmailAddress).HasComment("E-mail address for the person.");
            entity.Property(e => e.FirstName).HasComment("First name of the person.");
            entity.Property(e => e.LastName).HasComment("Last name of the person.");
            entity.Property(e => e.MiddleName).HasComment("Middle name or middle initial of the person.");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_Customer_ModifiedDate");
            entity.Property(e => e.NameStyle).HasComment("0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.");
            entity.Property(e => e.PasswordHash).HasComment("Password for the e-mail account.");
            entity.Property(e => e.PasswordSalt).HasComment("Random value concatenated with the password string before the password is hashed.");
            entity.Property(e => e.Phone).HasComment("Phone number associated with the person.");
            entity.Property(e => e.Rowguid)
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasDefaultValueSql("(newid())", "DF_Customer_rowguid");
            entity.Property(e => e.SalesPerson).HasComment("The customer's sales person, an employee of AdventureWorks Cycles.");
            entity.Property(e => e.Suffix).HasComment("Surname suffix. For example, Sr. or Jr.");
            entity.Property(e => e.Title).HasComment("A courtesy title. For example, Mr. or Ms.");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.AddressId }).HasName("PK_CustomerAddress_CustomerID_AddressID");

            entity.ToTable("CustomerAddress", "SalesLT", tb => tb.HasComment("Cross-reference table mapping customers to their address(es)."));

            entity.Property(e => e.CustomerId).HasComment("Primary key. Foreign key to Customer.CustomerID.");
            entity.Property(e => e.AddressId).HasComment("Primary key. Foreign key to Address.AddressID.");
            entity.Property(e => e.AddressType).HasComment("The kind of Address. One of: Archive, Billing, Home, Main Office, Primary, Shipping");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_CustomerAddress_ModifiedDate");
            entity.Property(e => e.Rowguid)
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasDefaultValueSql("(newid())", "DF_CustomerAddress_rowguid");

            entity.HasOne(d => d.Address).WithMany(p => p.CustomerAddresses).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.ErrorLogId).HasName("PK_ErrorLog_ErrorLogID");

            entity.ToTable("ErrorLog", tb => tb.HasComment("Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct."));

            entity.Property(e => e.ErrorLogId).HasComment("Primary key for ErrorLog records.");
            entity.Property(e => e.ErrorLine).HasComment("The line number at which the error occurred.");
            entity.Property(e => e.ErrorMessage).HasComment("The message text of the error that occurred.");
            entity.Property(e => e.ErrorNumber).HasComment("The error number of the error that occurred.");
            entity.Property(e => e.ErrorProcedure).HasComment("The name of the stored procedure or trigger where the error occurred.");
            entity.Property(e => e.ErrorSeverity).HasComment("The severity of the error that occurred.");
            entity.Property(e => e.ErrorState).HasComment("The state number of the error that occurred.");
            entity.Property(e => e.ErrorTime)
                .HasComment("The date and time at which the error occurred.")
                .HasDefaultValueSql("(getdate())", "DF_ErrorLog_ErrorTime");
            entity.Property(e => e.UserName).HasComment("The user who executed the batch in which the error occurred.");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product_ProductID");

            entity.ToTable("Product", "SalesLT", tb => tb.HasComment("Products sold or used in the manfacturing of sold products."));

            entity.Property(e => e.ProductId).HasComment("Primary key for Product records.");
            entity.Property(e => e.Color).HasComment("Product color.");
            entity.Property(e => e.DiscontinuedDate).HasComment("Date the product was discontinued.");
            entity.Property(e => e.ListPrice).HasComment("Selling price.");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_Product_ModifiedDate");
            entity.Property(e => e.Name).HasComment("Name of the product.");
            entity.Property(e => e.ProductCategoryId).HasComment("Product is a member of this product category. Foreign key to ProductCategory.ProductCategoryID. ");
            entity.Property(e => e.ProductModelId).HasComment("Product is a member of this product model. Foreign key to ProductModel.ProductModelID.");
            entity.Property(e => e.ProductNumber).HasComment("Unique product identification number.");
            entity.Property(e => e.Rowguid)
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasDefaultValueSql("(newid())", "DF_Product_rowguid");
            entity.Property(e => e.SellEndDate).HasComment("Date the product was no longer available for sale.");
            entity.Property(e => e.SellStartDate).HasComment("Date the product was available for sale.");
            entity.Property(e => e.Size).HasComment("Product size.");
            entity.Property(e => e.StandardCost).HasComment("Standard cost of the product.");
            entity.Property(e => e.ThumbNailPhoto).HasComment("Small image of the product.");
            entity.Property(e => e.ThumbnailPhotoFileName).HasComment("Small image file name.");
            entity.Property(e => e.Weight).HasComment("Product weight.");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK_ProductCategory_ProductCategoryID");

            entity.ToTable("ProductCategory", "SalesLT", tb => tb.HasComment("High-level product categorization."));

            entity.Property(e => e.ProductCategoryId).HasComment("Primary key for ProductCategory records.");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_ProductCategory_ModifiedDate");
            entity.Property(e => e.Name).HasComment("Category description.");
            entity.Property(e => e.ParentProductCategoryId).HasComment("Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.");
            entity.Property(e => e.Rowguid)
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasDefaultValueSql("(newid())", "DF_ProductCategory_rowguid");

            entity.HasOne(d => d.ParentProductCategory).WithMany(p => p.InverseParentProductCategory).HasConstraintName("FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID");
        });

        modelBuilder.Entity<ProductDescription>(entity =>
        {
            entity.HasKey(e => e.ProductDescriptionId).HasName("PK_ProductDescription_ProductDescriptionID");

            entity.ToTable("ProductDescription", "SalesLT", tb => tb.HasComment("Product descriptions in several languages."));

            entity.Property(e => e.ProductDescriptionId).HasComment("Primary key for ProductDescription records.");
            entity.Property(e => e.Description).HasComment("Description of the product.");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_ProductDescription_ModifiedDate");
            entity.Property(e => e.Rowguid)
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasDefaultValueSql("(newid())", "DF_ProductDescription_rowguid");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.ProductModelId).HasName("PK_ProductModel_ProductModelID");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())", "DF_ProductModel_ModifiedDate");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newid())", "DF_ProductModel_rowguid");
        });

        modelBuilder.Entity<ProductModelProductDescription>(entity =>
        {
            entity.HasKey(e => new { e.ProductModelId, e.ProductDescriptionId, e.Culture }).HasName("PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture");

            entity.ToTable("ProductModelProductDescription", "SalesLT", tb => tb.HasComment("Cross-reference table mapping product descriptions and the language the description is written in."));

            entity.Property(e => e.ProductModelId).HasComment("Primary key. Foreign key to ProductModel.ProductModelID.");
            entity.Property(e => e.ProductDescriptionId).HasComment("Primary key. Foreign key to ProductDescription.ProductDescriptionID.");
            entity.Property(e => e.Culture)
                .IsFixedLength()
                .HasComment("The culture for which the description is written");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_ProductModelProductDescription_ModifiedDate");
            entity.Property(e => e.Rowguid).HasDefaultValueSql("(newid())", "DF_ProductModelProductDescription_rowguid");

            entity.HasOne(d => d.ProductDescription).WithMany(p => p.ProductModelProductDescriptions).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductModel).WithMany(p => p.ProductModelProductDescriptions).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId }).HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

            entity.ToTable("SalesOrderDetail", "SalesLT", tb =>
                {
                    tb.HasComment("Individual products associated with a specific sales order. See SalesOrderHeader.");
                    tb.HasTrigger("iduSalesOrderDetail");
                });

            entity.Property(e => e.SalesOrderId).HasComment("Primary key. Foreign key to SalesOrderHeader.SalesOrderID.");
            entity.Property(e => e.SalesOrderDetailId)
                .ValueGeneratedOnAdd()
                .HasComment("Primary key. One incremental unique number per product sold.");
            entity.Property(e => e.LineTotal)
                .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false)
                .HasComment("Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_SalesOrderDetail_ModifiedDate");
            entity.Property(e => e.OrderQty).HasComment("Quantity ordered per product.");
            entity.Property(e => e.ProductId).HasComment("Product sold to customer. Foreign key to Product.ProductID.");
            entity.Property(e => e.Rowguid)
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasDefaultValueSql("(newid())", "DF_SalesOrderDetail_rowguid");
            entity.Property(e => e.UnitPrice).HasComment("Selling price of a single product.");
            entity.Property(e => e.UnitPriceDiscount).HasComment("Discount amount.");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesOrderDetails).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesOrderHeader>(entity =>
        {
            entity.HasKey(e => e.SalesOrderId).HasName("PK_SalesOrderHeader_SalesOrderID");

            entity.ToTable("SalesOrderHeader", "SalesLT", tb =>
                {
                    tb.HasComment("General sales order information.");
                    tb.HasTrigger("uSalesOrderHeader");
                });

            entity.Property(e => e.SalesOrderId).HasComment("Primary key.");
            entity.Property(e => e.AccountNumber).HasComment("Financial accounting number reference.");
            entity.Property(e => e.BillToAddressId).HasComment("The ID of the location to send invoices.  Foreign key to the Address table.");
            entity.Property(e => e.Comment).HasComment("Sales representative comments.");
            entity.Property(e => e.CreditCardApprovalCode).HasComment("Approval code provided by the credit card company.");
            entity.Property(e => e.CustomerId).HasComment("Customer identification number. Foreign key to Customer.CustomerID.");
            entity.Property(e => e.DueDate).HasComment("Date the order is due to the customer.");
            entity.Property(e => e.Freight).HasComment("Shipping cost.");
            entity.Property(e => e.ModifiedDate)
                .HasComment("Date and time the record was last updated.")
                .HasDefaultValueSql("(getdate())", "DF_SalesOrderHeader_ModifiedDate");
            entity.Property(e => e.OnlineOrderFlag)
                .HasComment("0 = Order placed by sales person. 1 = Order placed online by customer.")
                .HasDefaultValue(true, "DF_SalesOrderHeader_OnlineOrderFlag");
            entity.Property(e => e.OrderDate)
                .HasComment("Dates the sales order was created.")
                .HasDefaultValueSql("(getdate())", "DF_SalesOrderHeader_OrderDate");
            entity.Property(e => e.PurchaseOrderNumber).HasComment("Customer purchase order number reference. ");
            entity.Property(e => e.RevisionNumber).HasComment("Incremental number to track changes to the sales order over time.");
            entity.Property(e => e.Rowguid)
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
                .HasDefaultValueSql("(newid())", "DF_SalesOrderHeader_rowguid");
            entity.Property(e => e.SalesOrderNumber)
                .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))", false)
                .HasComment("Unique sales order identification number.");
            entity.Property(e => e.ShipDate).HasComment("Date the order was shipped to the customer.");
            entity.Property(e => e.ShipMethod).HasComment("Shipping method. Foreign key to ShipMethod.ShipMethodID.");
            entity.Property(e => e.ShipToAddressId).HasComment("The ID of the location to send goods.  Foreign key to the Address table.");
            entity.Property(e => e.Status)
                .HasComment("Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled")
                .HasDefaultValue((byte)1, "DF_SalesOrderHeader_Status");
            entity.Property(e => e.SubTotal).HasComment("Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.");
            entity.Property(e => e.TaxAmt).HasComment("Tax amount.");
            entity.Property(e => e.TotalDue)
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", false)
                .HasComment("Total due from customer. Computed as Subtotal + TaxAmt + Freight.");

            entity.HasOne(d => d.BillToAddress).WithMany(p => p.SalesOrderHeaderBillToAddresses).HasConstraintName("FK_SalesOrderHeader_Address_BillTo_AddressID");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrderHeaders).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ShipToAddress).WithMany(p => p.SalesOrderHeaderShipToAddresses).HasConstraintName("FK_SalesOrderHeader_Address_ShipTo_AddressID");
        });

        modelBuilder.Entity<VGetAllCategory>(entity =>
        {
            entity.ToView("vGetAllCategories", "SalesLT");
        });

        modelBuilder.Entity<VProductAndDescription>(entity =>
        {
            entity.ToView("vProductAndDescription", "SalesLT");

            entity.Property(e => e.Culture).IsFixedLength();
        });

        modelBuilder.Entity<VProductModelCatalogDescription>(entity =>
        {
            entity.ToView("vProductModelCatalogDescription", "SalesLT");

            entity.Property(e => e.ProductModelId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
