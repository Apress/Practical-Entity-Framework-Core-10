# Listing 7-12: Ensure the Rollback will remove the new procedure

Leverage the Down method to ensure that a rollback will make sure the procedure is removed.

## The Code

Place the following code in the Down method in the new migration to revert on rollback.

```cs  
migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[GetItemsByGenre]");
```  