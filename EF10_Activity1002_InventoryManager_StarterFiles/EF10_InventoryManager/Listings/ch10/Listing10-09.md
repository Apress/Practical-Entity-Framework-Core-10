# Listing 10-9: Drop the PIINumber Column

Create a new miration named `Drop_PIINumber_Column` to drop the `PIINumber` column.

## The Migration

```sql
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropColumn(
        name: "PIINumber",
        table: "Items");
}
```  

Full Migration:

```sql
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropColumn(
        name: "PIINumber",
        table: "Items");
}

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AddColumn<string>(
        name: "PIINumber",
        table: "Items",
        type: "nvarchar(50)",
        maxLength: 50,
        nullable: true);

    //delete all the update commands or leave them, your choice.
}
```  