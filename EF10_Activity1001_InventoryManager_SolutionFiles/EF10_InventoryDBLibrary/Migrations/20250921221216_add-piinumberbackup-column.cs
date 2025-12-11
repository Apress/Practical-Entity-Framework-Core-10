using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

#nullable disable

namespace EF10_InventoryDBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class addpiinumberbackupcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PIINumberBackup",
                table: "Items",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Operations.BackupColumnsForTDE.sql");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PIINumberBackup",
                table: "Items");
        }
    }
}
