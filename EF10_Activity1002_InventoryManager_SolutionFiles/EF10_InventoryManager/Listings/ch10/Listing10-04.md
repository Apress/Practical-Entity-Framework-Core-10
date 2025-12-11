# Listing 10-4: The script to update the items

Create a script named `BackupColumnsForTDE.sql` unser the `Scripts/Operations` folder.  Add the SQL below.

## The script

Use this script to copy all the data from `PIINumber` into `PIINumberBackup`.

```sql
UPDATE Items
SET PIINumberBackup = PIINumber
```  