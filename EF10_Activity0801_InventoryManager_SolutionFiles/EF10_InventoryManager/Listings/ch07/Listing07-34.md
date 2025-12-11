# Listing 7-34: Ensure the View is removed on rollback

Make sure to add code to the Down method to rollback the changes.

## Code

Use this code to ensure the view would be dropped if the changes were rolled back.

```cs  
migrationBuilder.Sql(@"DROP VIEW IF EXISTS dbo.vwItemsWithGenresAndContributors");  
```  
