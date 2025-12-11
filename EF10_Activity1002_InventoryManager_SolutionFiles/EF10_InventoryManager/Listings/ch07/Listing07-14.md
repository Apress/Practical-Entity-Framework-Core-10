# Run the procedure from SSMS to validate

Once the migration is applied, you can leverage it from code or from SSMS.

## The T-SQL to validate the procedure is applied

Use the following T-SQL code to test that the new procedure is working as expected.

```sql
exec [dbo].[GetItemsByGenre] 'Action', 1
```  

>**Note:** the 1 is optional as the default is set to get active items

Try sending some of the other Genres to see the various results.  