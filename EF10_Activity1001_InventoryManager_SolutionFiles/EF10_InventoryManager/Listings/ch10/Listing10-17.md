# Listing 10-17: Remove the PIINumberBackup column

Add a final new migration `remove-piinumber-backup-column` and make sure it is set to remove the `PIINumberBackup` column in the `Up` method.  Also delete all the unnecessary `Update` statements in the `Down` method.

## The code

```cs
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropColumn(
        name: "PIINumberBackup",
        table: "Items");
}
```  

## The full migration

Here is the full migration (expected), with extra `Update` statements manually removed.

```cs
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF10_InventoryDBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class removepiinumberbackupcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PIINumberBackup",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PIINumberBackup",
                table: "Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
```  
