# Listing 10-14: Update the table to restore original data as encrypted

Create a new script file under Scripts\Operations called `RestorePIINumberEncrypted.sql` and add the sql from below to use the backup column to encrypt the data and put the correct PIINumber in the encrypted column.

## The Script

This script will copy the backup data into the PIINumber column as it's encrypted value.  This will be run via migration, but you can test in SSMS if you would like.

```sql
OPEN SYMMETRIC KEY IMDB_ColumnKey
    DECRYPTION BY CERTIFICATE IMDB_tdeCert;
UPDATE ITEMS
SET PIINumber = ENCRYPTBYKEY(KEY_GUID('IMDB_ColumnKey'), PIINumberBackup)
CLOSE SYMMETRIC KEY IMDB_ColumnKey;
```  