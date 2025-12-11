using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF10_AWDBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.EnsureSchema(
            //     name: "SalesLT");

            // migrationBuilder.CreateTable(
            //     name: "Address",
            //     schema: "SalesLT",
            //     columns: table => new
            //     {
            //         AddressID = table.Column<int>(type: "int", nullable: false, comment: "Primary key for Address records.")
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         AddressLine1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "First street address line."),
            //         AddressLine2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, comment: "Second street address line."),
            //         City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the city."),
            //         StateProvince = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of state or province."),
            //         CountryRegion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //         PostalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Postal code for the street address."),
            //         rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_Address_rowguid"),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_Address_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Address_AddressID", x => x.AddressID);
            //     },
            //     comment: "Street address information for customers.");

            // migrationBuilder.CreateTable(
            //     name: "BuildVersion",
            //     columns: table => new
            //     {
            //         SystemInformationID = table.Column<byte>(type: "tinyint", nullable: false, comment: "Primary key for BuildVersion records.")
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         DatabaseVersion = table.Column<string>(name: "Database Version", type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Version number of the database in 9.yy.mm.dd.00 format."),
            //         VersionDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date and time the record was last updated."),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_BuildVersion_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //     },
            //     comment: "Current version number of the AdventureWorksLT 2012 sample database. ");

            // migrationBuilder.CreateTable(
            //     name: "Customer",
            //     schema: "SalesLT",
            //     columns: table => new
            //     {
            //         CustomerID = table.Column<int>(type: "int", nullable: false, comment: "Primary key for Customer records.")
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         NameStyle = table.Column<bool>(type: "bit", nullable: false, comment: "0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order."),
            //         Title = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true, comment: "A courtesy title. For example, Mr. or Ms."),
            //         FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "First name of the person."),
            //         MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Middle name or middle initial of the person."),
            //         LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Last name of the person."),
            //         Suffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Surname suffix. For example, Sr. or Jr."),
            //         CompanyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true, comment: "The customer's organization."),
            //         SalesPerson = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "The customer's sales person, an employee of AdventureWorks Cycles."),
            //         EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "E-mail address for the person."),
            //         Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "Phone number associated with the person."),
            //         PasswordHash = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false, comment: "Password for the e-mail account."),
            //         PasswordSalt = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, comment: "Random value concatenated with the password string before the password is hashed."),
            //         rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_Customer_rowguid"),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_Customer_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Customer_CustomerID", x => x.CustomerID);
            //     },
            //     comment: "Customer information.");

            // migrationBuilder.CreateTable(
            //     name: "ErrorLog",
            //     columns: table => new
            //     {
            //         ErrorLogID = table.Column<int>(type: "int", nullable: false, comment: "Primary key for ErrorLog records.")
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         ErrorTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "The date and time at which the error occurred.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_ErrorLog_ErrorTime"),
            //         UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The user who executed the batch in which the error occurred."),
            //         ErrorNumber = table.Column<int>(type: "int", nullable: false, comment: "The error number of the error that occurred."),
            //         ErrorSeverity = table.Column<int>(type: "int", nullable: true, comment: "The severity of the error that occurred."),
            //         ErrorState = table.Column<int>(type: "int", nullable: true, comment: "The state number of the error that occurred."),
            //         ErrorProcedure = table.Column<string>(type: "nvarchar(126)", maxLength: 126, nullable: true, comment: "The name of the stored procedure or trigger where the error occurred."),
            //         ErrorLine = table.Column<int>(type: "int", nullable: true, comment: "The line number at which the error occurred."),
            //         ErrorMessage = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false, comment: "The message text of the error that occurred.")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_ErrorLog_ErrorLogID", x => x.ErrorLogID);
            //     },
            //     comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct.");

            // migrationBuilder.CreateTable(
            //     name: "ProductCategory",
            //     schema: "SalesLT",
            //     columns: table => new
            //     {
            //         ProductCategoryID = table.Column<int>(type: "int", nullable: false, comment: "Primary key for ProductCategory records.")
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         ParentProductCategoryID = table.Column<int>(type: "int", nullable: true, comment: "Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID."),
            //         Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category description."),
            //         rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_ProductCategory_rowguid"),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_ProductCategory_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_ProductCategory_ProductCategoryID", x => x.ProductCategoryID);
            //         table.ForeignKey(
            //             name: "FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID",
            //             column: x => x.ParentProductCategoryID,
            //             principalSchema: "SalesLT",
            //             principalTable: "ProductCategory",
            //             principalColumn: "ProductCategoryID");
            //     },
            //     comment: "High-level product categorization.");

            // migrationBuilder.CreateTable(
            //     name: "ProductDescription",
            //     schema: "SalesLT",
            //     columns: table => new
            //     {
            //         ProductDescriptionID = table.Column<int>(type: "int", nullable: false, comment: "Primary key for ProductDescription records.")
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false, comment: "Description of the product."),
            //         rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_ProductDescription_rowguid"),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_ProductDescription_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_ProductDescription_ProductDescriptionID", x => x.ProductDescriptionID);
            //     },
            //     comment: "Product descriptions in several languages.");

            // migrationBuilder.CreateTable(
            //     name: "ProductModel",
            //     schema: "SalesLT",
            //     columns: table => new
            //     {
            //         ProductModelID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //         CatalogDescription = table.Column<string>(type: "xml", nullable: true),
            //         rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
            //             .Annotation("Relational:DefaultConstraintName", "DF_ProductModel_rowguid"),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //             .Annotation("Relational:DefaultConstraintName", "DF_ProductModel_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_ProductModel_ProductModelID", x => x.ProductModelID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "CustomerAddress",
            //     schema: "SalesLT",
            //     columns: table => new
            //     {
            //         CustomerID = table.Column<int>(type: "int", nullable: false, comment: "Primary key. Foreign key to Customer.CustomerID."),
            //         AddressID = table.Column<int>(type: "int", nullable: false, comment: "Primary key. Foreign key to Address.AddressID."),
            //         AddressType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The kind of Address. One of: Archive, Billing, Home, Main Office, Primary, Shipping"),
            //         rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_CustomerAddress_rowguid"),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_CustomerAddress_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_CustomerAddress_CustomerID_AddressID", x => new { x.CustomerID, x.AddressID });
            //         table.ForeignKey(
            //             name: "FK_CustomerAddress_Address_AddressID",
            //             column: x => x.AddressID,
            //             principalSchema: "SalesLT",
            //             principalTable: "Address",
            //             principalColumn: "AddressID");
            //         table.ForeignKey(
            //             name: "FK_CustomerAddress_Customer_CustomerID",
            //             column: x => x.CustomerID,
            //             principalSchema: "SalesLT",
            //             principalTable: "Customer",
            //             principalColumn: "CustomerID");
            //     },
            //     comment: "Cross-reference table mapping customers to their address(es).");

            // migrationBuilder.CreateTable(
            //     name: "SalesOrderHeader",
            //     schema: "SalesLT",
            //     columns: table => new
            //     {
            //         SalesOrderID = table.Column<int>(type: "int", nullable: false, comment: "Primary key.")
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         RevisionNumber = table.Column<byte>(type: "tinyint", nullable: false, comment: "Incremental number to track changes to the sales order over time."),
            //         OrderDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Dates the sales order was created.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_SalesOrderHeader_OrderDate"),
            //         DueDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date the order is due to the customer."),
            //         ShipDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Date the order was shipped to the customer."),
            //         Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1, comment: "Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled")
            //             .Annotation("Relational:DefaultConstraintName", "DF_SalesOrderHeader_Status"),
            //         OnlineOrderFlag = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "0 = Order placed by sales person. 1 = Order placed online by customer.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_SalesOrderHeader_OnlineOrderFlag"),
            //         SalesOrderNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, computedColumnSql: "(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))", stored: false, comment: "Unique sales order identification number."),
            //         PurchaseOrderNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "Customer purchase order number reference. "),
            //         AccountNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "Financial accounting number reference."),
            //         CustomerID = table.Column<int>(type: "int", nullable: false, comment: "Customer identification number. Foreign key to Customer.CustomerID."),
            //         ShipToAddressID = table.Column<int>(type: "int", nullable: true, comment: "The ID of the location to send goods.  Foreign key to the Address table."),
            //         BillToAddressID = table.Column<int>(type: "int", nullable: true, comment: "The ID of the location to send invoices.  Foreign key to the Address table."),
            //         ShipMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Shipping method. Foreign key to ShipMethod.ShipMethodID."),
            //         CreditCardApprovalCode = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true, comment: "Approval code provided by the credit card company."),
            //         SubTotal = table.Column<decimal>(type: "money", nullable: false, comment: "Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID."),
            //         TaxAmt = table.Column<decimal>(type: "money", nullable: false, comment: "Tax amount."),
            //         Freight = table.Column<decimal>(type: "money", nullable: false, comment: "Shipping cost."),
            //         TotalDue = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", stored: false, comment: "Total due from customer. Computed as Subtotal + TaxAmt + Freight."),
            //         Comment = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Sales representative comments."),
            //         rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_SalesOrderHeader_rowguid"),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_SalesOrderHeader_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_SalesOrderHeader_SalesOrderID", x => x.SalesOrderID);
            //         table.ForeignKey(
            //             name: "FK_SalesOrderHeader_Address_BillTo_AddressID",
            //             column: x => x.BillToAddressID,
            //             principalSchema: "SalesLT",
            //             principalTable: "Address",
            //             principalColumn: "AddressID");
            //         table.ForeignKey(
            //             name: "FK_SalesOrderHeader_Address_ShipTo_AddressID",
            //             column: x => x.ShipToAddressID,
            //             principalSchema: "SalesLT",
            //             principalTable: "Address",
            //             principalColumn: "AddressID");
            //         table.ForeignKey(
            //             name: "FK_SalesOrderHeader_Customer_CustomerID",
            //             column: x => x.CustomerID,
            //             principalSchema: "SalesLT",
            //             principalTable: "Customer",
            //             principalColumn: "CustomerID");
            //     },
            //     comment: "General sales order information.");

            // migrationBuilder.CreateTable(
            //     name: "Product",
            //     schema: "SalesLT",
            //     columns: table => new
            //     {
            //         ProductID = table.Column<int>(type: "int", nullable: false, comment: "Primary key for Product records.")
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the product."),
            //         ProductNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Unique product identification number."),
            //         Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "Product color."),
            //         StandardCost = table.Column<decimal>(type: "money", nullable: false, comment: "Standard cost of the product."),
            //         ListPrice = table.Column<decimal>(type: "money", nullable: false, comment: "Selling price."),
            //         Size = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true, comment: "Product size."),
            //         Weight = table.Column<decimal>(type: "decimal(8,2)", nullable: true, comment: "Product weight."),
            //         ProductCategoryID = table.Column<int>(type: "int", nullable: true, comment: "Product is a member of this product category. Foreign key to ProductCategory.ProductCategoryID. "),
            //         ProductModelID = table.Column<int>(type: "int", nullable: true, comment: "Product is a member of this product model. Foreign key to ProductModel.ProductModelID."),
            //         SellStartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date the product was available for sale."),
            //         SellEndDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Date the product was no longer available for sale."),
            //         DiscontinuedDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Date the product was discontinued."),
            //         ThumbNailPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "Small image of the product."),
            //         ThumbnailPhotoFileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Small image file name."),
            //         rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_Product_rowguid"),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_Product_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Product_ProductID", x => x.ProductID);
            //         table.ForeignKey(
            //             name: "FK_Product_ProductCategory_ProductCategoryID",
            //             column: x => x.ProductCategoryID,
            //             principalSchema: "SalesLT",
            //             principalTable: "ProductCategory",
            //             principalColumn: "ProductCategoryID");
            //         table.ForeignKey(
            //             name: "FK_Product_ProductModel_ProductModelID",
            //             column: x => x.ProductModelID,
            //             principalSchema: "SalesLT",
            //             principalTable: "ProductModel",
            //             principalColumn: "ProductModelID");
            //     },
            //     comment: "Products sold or used in the manfacturing of sold products.");

            // migrationBuilder.CreateTable(
            //     name: "ProductModelProductDescription",
            //     schema: "SalesLT",
            //     columns: table => new
            //     {
            //         ProductModelID = table.Column<int>(type: "int", nullable: false, comment: "Primary key. Foreign key to ProductModel.ProductModelID."),
            //         ProductDescriptionID = table.Column<int>(type: "int", nullable: false, comment: "Primary key. Foreign key to ProductDescription.ProductDescriptionID."),
            //         Culture = table.Column<string>(type: "nchar(6)", fixedLength: true, maxLength: 6, nullable: false, comment: "The culture for which the description is written"),
            //         rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
            //             .Annotation("Relational:DefaultConstraintName", "DF_ProductModelProductDescription_rowguid"),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_ProductModelProductDescription_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture", x => new { x.ProductModelID, x.ProductDescriptionID, x.Culture });
            //         table.ForeignKey(
            //             name: "FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID",
            //             column: x => x.ProductDescriptionID,
            //             principalSchema: "SalesLT",
            //             principalTable: "ProductDescription",
            //             principalColumn: "ProductDescriptionID");
            //         table.ForeignKey(
            //             name: "FK_ProductModelProductDescription_ProductModel_ProductModelID",
            //             column: x => x.ProductModelID,
            //             principalSchema: "SalesLT",
            //             principalTable: "ProductModel",
            //             principalColumn: "ProductModelID");
            //     },
            //     comment: "Cross-reference table mapping product descriptions and the language the description is written in.");

            // migrationBuilder.CreateTable(
            //     name: "SalesOrderDetail",
            //     schema: "SalesLT",
            //     columns: table => new
            //     {
            //         SalesOrderID = table.Column<int>(type: "int", nullable: false, comment: "Primary key. Foreign key to SalesOrderHeader.SalesOrderID."),
            //         SalesOrderDetailID = table.Column<int>(type: "int", nullable: false, comment: "Primary key. One incremental unique number per product sold.")
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         OrderQty = table.Column<short>(type: "smallint", nullable: false, comment: "Quantity ordered per product."),
            //         ProductID = table.Column<int>(type: "int", nullable: false, comment: "Product sold to customer. Foreign key to Product.ProductID."),
            //         UnitPrice = table.Column<decimal>(type: "money", nullable: false, comment: "Selling price of a single product."),
            //         UnitPriceDiscount = table.Column<decimal>(type: "money", nullable: false, comment: "Discount amount."),
            //         LineTotal = table.Column<decimal>(type: "numeric(38,6)", nullable: false, computedColumnSql: "(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", stored: false, comment: "Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty."),
            //         rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_SalesOrderDetail_rowguid"),
            //         ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
            //             .Annotation("Relational:DefaultConstraintName", "DF_SalesOrderDetail_ModifiedDate")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID", x => new { x.SalesOrderID, x.SalesOrderDetailID });
            //         table.ForeignKey(
            //             name: "FK_SalesOrderDetail_Product_ProductID",
            //             column: x => x.ProductID,
            //             principalSchema: "SalesLT",
            //             principalTable: "Product",
            //             principalColumn: "ProductID");
            //         table.ForeignKey(
            //             name: "FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID",
            //             column: x => x.SalesOrderID,
            //             principalSchema: "SalesLT",
            //             principalTable: "SalesOrderHeader",
            //             principalColumn: "SalesOrderID",
            //             onDelete: ReferentialAction.Cascade);
            //     },
            //     comment: "Individual products associated with a specific sales order. See SalesOrderHeader.");

            // migrationBuilder.CreateIndex(
            //     name: "AK_Address_rowguid",
            //     schema: "SalesLT",
            //     table: "Address",
            //     column: "rowguid",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Address_AddressLine1_AddressLine2_City_StateProvince_PostalCode_CountryRegion",
            //     schema: "SalesLT",
            //     table: "Address",
            //     columns: new[] { "AddressLine1", "AddressLine2", "City", "StateProvince", "PostalCode", "CountryRegion" });

            // migrationBuilder.CreateIndex(
            //     name: "IX_Address_StateProvince",
            //     schema: "SalesLT",
            //     table: "Address",
            //     column: "StateProvince");

            // migrationBuilder.CreateIndex(
            //     name: "AK_Customer_rowguid",
            //     schema: "SalesLT",
            //     table: "Customer",
            //     column: "rowguid",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Customer_EmailAddress",
            //     schema: "SalesLT",
            //     table: "Customer",
            //     column: "EmailAddress");

            // migrationBuilder.CreateIndex(
            //     name: "AK_CustomerAddress_rowguid",
            //     schema: "SalesLT",
            //     table: "CustomerAddress",
            //     column: "rowguid",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_CustomerAddress_AddressID",
            //     schema: "SalesLT",
            //     table: "CustomerAddress",
            //     column: "AddressID");

            // migrationBuilder.CreateIndex(
            //     name: "AK_Product_Name",
            //     schema: "SalesLT",
            //     table: "Product",
            //     column: "Name",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "AK_Product_ProductNumber",
            //     schema: "SalesLT",
            //     table: "Product",
            //     column: "ProductNumber",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "AK_Product_rowguid",
            //     schema: "SalesLT",
            //     table: "Product",
            //     column: "rowguid",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Product_ProductCategoryID",
            //     schema: "SalesLT",
            //     table: "Product",
            //     column: "ProductCategoryID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Product_ProductModelID",
            //     schema: "SalesLT",
            //     table: "Product",
            //     column: "ProductModelID");

            // migrationBuilder.CreateIndex(
            //     name: "AK_ProductCategory_Name",
            //     schema: "SalesLT",
            //     table: "ProductCategory",
            //     column: "Name",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "AK_ProductCategory_rowguid",
            //     schema: "SalesLT",
            //     table: "ProductCategory",
            //     column: "rowguid",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_ProductCategory_ParentProductCategoryID",
            //     schema: "SalesLT",
            //     table: "ProductCategory",
            //     column: "ParentProductCategoryID");

            // migrationBuilder.CreateIndex(
            //     name: "AK_ProductDescription_rowguid",
            //     schema: "SalesLT",
            //     table: "ProductDescription",
            //     column: "rowguid",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "AK_ProductModel_Name",
            //     schema: "SalesLT",
            //     table: "ProductModel",
            //     column: "Name",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "AK_ProductModel_rowguid",
            //     schema: "SalesLT",
            //     table: "ProductModel",
            //     column: "rowguid",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "PXML_ProductModel_CatalogDescription",
            //     schema: "SalesLT",
            //     table: "ProductModel",
            //     column: "CatalogDescription");

            // migrationBuilder.CreateIndex(
            //     name: "AK_ProductModelProductDescription_rowguid",
            //     schema: "SalesLT",
            //     table: "ProductModelProductDescription",
            //     column: "rowguid",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_ProductModelProductDescription_ProductDescriptionID",
            //     schema: "SalesLT",
            //     table: "ProductModelProductDescription",
            //     column: "ProductDescriptionID");

            // migrationBuilder.CreateIndex(
            //     name: "AK_SalesOrderDetail_rowguid",
            //     schema: "SalesLT",
            //     table: "SalesOrderDetail",
            //     column: "rowguid",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_SalesOrderDetail_ProductID",
            //     schema: "SalesLT",
            //     table: "SalesOrderDetail",
            //     column: "ProductID");

            // migrationBuilder.CreateIndex(
            //     name: "AK_SalesOrderHeader_rowguid",
            //     schema: "SalesLT",
            //     table: "SalesOrderHeader",
            //     column: "rowguid",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "AK_SalesOrderHeader_SalesOrderNumber",
            //     schema: "SalesLT",
            //     table: "SalesOrderHeader",
            //     column: "SalesOrderNumber",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_SalesOrderHeader_BillToAddressID",
            //     schema: "SalesLT",
            //     table: "SalesOrderHeader",
            //     column: "BillToAddressID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SalesOrderHeader_CustomerID",
            //     schema: "SalesLT",
            //     table: "SalesOrderHeader",
            //     column: "CustomerID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_SalesOrderHeader_ShipToAddressID",
            //     schema: "SalesLT",
            //     table: "SalesOrderHeader",
            //     column: "ShipToAddressID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //In the book, you are instructed to delete the code in the Down() method.
            //However, for completeness, the original code is commented out below.

            // migrationBuilder.DropTable(
            //     name: "BuildVersion");

            // migrationBuilder.DropTable(
            //     name: "CustomerAddress",
            //     schema: "SalesLT");

            // migrationBuilder.DropTable(
            //     name: "ErrorLog");

            // migrationBuilder.DropTable(
            //     name: "ProductModelProductDescription",
            //     schema: "SalesLT");

            // migrationBuilder.DropTable(
            //     name: "SalesOrderDetail",
            //     schema: "SalesLT");

            // migrationBuilder.DropTable(
            //     name: "ProductDescription",
            //     schema: "SalesLT");

            // migrationBuilder.DropTable(
            //     name: "Product",
            //     schema: "SalesLT");

            // migrationBuilder.DropTable(
            //     name: "SalesOrderHeader",
            //     schema: "SalesLT");

            // migrationBuilder.DropTable(
            //     name: "ProductCategory",
            //     schema: "SalesLT");

            // migrationBuilder.DropTable(
            //     name: "ProductModel",
            //     schema: "SalesLT");

            // migrationBuilder.DropTable(
            //     name: "Address",
            //     schema: "SalesLT");

            // migrationBuilder.DropTable(
            //     name: "Customer",
            //     schema: "SalesLT");
        }
    }
}
