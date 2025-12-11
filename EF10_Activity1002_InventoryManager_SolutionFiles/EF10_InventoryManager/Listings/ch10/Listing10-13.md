# Listing 10-13: Quick Encrypt

Run this script manually to perform a quick update of the column data to the same value for all rows. You wouldn't do this in the migration, this is just for learning and demonstration only.

## The manual script

Run this script to quickly add some data to the `PIINumber` column:

```sql
OPEN SYMMETRIC KEY IMDB_ColumnKey
    DECRYPTION BY CERTIFICATE IMDB_tdeCert;

UPDATE ITEMS
SET PIINumber = ENCRYPTBYKEY(KEY_GUID('IMDB_ColumnKey'), '123-45-6789')

CLOSE SYMMETRIC KEY IMDB_ColumnKey;
```  