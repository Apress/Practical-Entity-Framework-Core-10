# Listing 10-16: Reviewing the data

Use the script below to query the database and show encrypted values

## SQL

Use the following T-SQL to see the data with the field decrypted.

```cs
OPEN SYMMETRIC KEY IMDB_ColumnKey
    DECRYPTION BY CERTIFICATE IMDB_tdeCert;
SELECT Id, Name
        , PIINumberBackup
        , CONVERT(nvarchar(50), DECRYPTBYKEY(PIINumber)) as PIINumber FROM ITEMS
CLOSE SYMMETRIC KEY IMDB_ColumnKey;
```  