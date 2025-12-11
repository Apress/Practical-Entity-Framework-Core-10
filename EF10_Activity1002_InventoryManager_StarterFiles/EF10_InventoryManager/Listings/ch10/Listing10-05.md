# Listing 10-5: The migrationBuilder.SqlResource statement

## The statement to add

```bash
migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Operations.BackupColumnsForTDE.sql");
```  

The full migration:

```cs
public partial class piinumberbackupcolumn : Migration
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
```  