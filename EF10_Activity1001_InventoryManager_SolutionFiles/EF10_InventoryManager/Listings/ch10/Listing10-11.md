# Listing 10-11: The migration to create the binary PIINumber column

Add a new migration `make_piinumber_binary` to create the column for `PIINumber` as a `byte[]`?

## Sql

The migration should look similar to what is shown below:

```cs
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AddColumn<byte[]>(
        name: "PIINumber",
        table: "Items",
        type: "varbinary(max)",
        nullable: true);
}
```  

Full migration:

```cs
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AddColumn<byte[]>(
        name: "PIINumber",
        table: "Items",
        type: "varbinary(max)",
        nullable: true);
}

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropColumn(
        name: "PIINumber",
        table: "Items");
}
```  
