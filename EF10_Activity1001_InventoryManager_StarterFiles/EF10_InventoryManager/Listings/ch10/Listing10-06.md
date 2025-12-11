# Listing 10-6: The script to create encryption keys

Use the following script to create a file to run in your migration

## The Script

Add to a new file `GenerateCertsAndKeys.sql` in the `Migrations/Scripts/Operations` folder.

If you are using NON-Container Storage:

```sql
IF NOT EXISTS (SELECT * FROM sys.symmetric_keys WHERE symmetric_key_id = 101)
BEGIN
    CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'Password#123!'
END

IF NOT EXISTS (SELECT 1 FROM sys.certificates WHERE name = N'IMDB_tdeCert')
BEGIN
    CREATE CERTIFICATE IMDB_tdeCert 
    WITH SUBJECT = 'Inventory Manager DB TDE Certificate'
END  

--note: if this fails you can delete and run again
BACKUP CERTIFICATE IMDB_tdeCert TO 
FILE = 'C:\Data\DatabaseKeys\IMDB_tdeCert.crt'
WITH PRIVATE KEY
(
    FILE = 'C:\Data\DatabaseKeys\IMDB_tdeCert_PrivateKey.crt',
    ENCRYPTION BY PASSWORD = 'Password#123!'
)

IF NOT EXISTS (
    SELECT 1
    FROM sys.symmetric_keys
    WHERE name = 'IMDB_ColumnKey'
)
BEGIN
    CREATE SYMMETRIC KEY IMDB_ColumnKey
    WITH ALGORITHM = AES_256
    ENCRYPTION BY CERTIFICATE IMDB_tdeCert;
END
```  

Using Container Storage:

```sql
IF NOT EXISTS (SELECT * FROM sys.symmetric_keys WHERE symmetric_key_id = 101)
BEGIN
    CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'Password#123!'
END

IF NOT EXISTS (SELECT 1 FROM sys.certificates WHERE name = N'IMDB_tdeCert')
BEGIN
    CREATE CERTIFICATE IMDB_tdeCert 
    WITH SUBJECT = 'Inventory Manager DB TDE Certificate'
END  

--note: if this fails you can delete and run again
--note2: mount a new folder for certs and use that as a better practice
BACKUP CERTIFICATE IMDB_tdeCert TO 
FILE = '/var/opt/mssql/backup/IMDB_tdeCert.crt'
WITH PRIVATE KEY
(
    FILE = '/var/opt/mssql/backup/IMDB_tdeCert_PrivateKey.crt',
    ENCRYPTION BY PASSWORD = 'Password#123!'
)

IF NOT EXISTS (
    SELECT 1
    FROM sys.symmetric_keys
    WHERE name = 'IMDB_ColumnKey'
)
BEGIN
    CREATE SYMMETRIC KEY IMDB_ColumnKey
    WITH ALGORITHM = AES_256
    ENCRYPTION BY CERTIFICATE IMDB_tdeCert;
END
```  