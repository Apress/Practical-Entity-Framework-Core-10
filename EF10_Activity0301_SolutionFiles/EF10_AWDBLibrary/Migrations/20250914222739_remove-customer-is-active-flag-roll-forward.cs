using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF10_AWDBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class removecustomerisactiveflagrollforward : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "SalesLT",
                table: "Customer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "SalesLT",
                table: "Customer",
                type: "bit",
                nullable: true);
        }
    }
}
