# Listing 14-10 - Bulk Delete Junk Data with Execute Delete Async

This operation will create and then bulk delete some Junk Data from the solution

## The code

Use the following code to replace the TODO comment BulkDeleteDemo:

```cs
int countJTD = await _db.JunkToBulkDeletes
    .Where(j => j.Name.Contains("BadData"))
    .ExecuteDeleteAsync();
```  

>**Note:** As a reminder, the Bulk operations (Update/Delete) do not call to save changes, so this bulk delete operation will BYPASS the SaveChanges interceptor, and actually delete data from the database without remorse or any ability to undo the action (unless you wrap it in a transaction - although even that might not be safe, so realy, just make sure to use this option very cautiously)