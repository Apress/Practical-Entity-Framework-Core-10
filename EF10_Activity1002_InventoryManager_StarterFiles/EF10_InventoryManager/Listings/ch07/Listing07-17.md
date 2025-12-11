# Listing 7-17: The migration for the fnGetContributorScore

This is the code that shows what should be in the Up and Down methods of the migration

## The createfnGetContributorScore migration

Use this code to validate your code that you put in your migration:

```cs
public partial class createfnGetContributorScore : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Functions.GetContributorScore.fnGetContributorScore_v0.sql");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS dbo.fnGetContributorScore");
    }
}
```  

>**Note:** Make sure you don't have nay typos in the folder path or file name