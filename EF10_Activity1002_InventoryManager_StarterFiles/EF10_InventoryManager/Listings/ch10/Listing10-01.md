# Listing 10-01: Enable TDE for the Database

This script will create a Database Encryption Key (DEK) stored to the local dist, then use that key to create TDE for the entire database.

## The Script

Use the following script to enable TDO on the entire database (encrypts the files on disk only, not the columns)

```sql
-- ==========================================
-- Transparent Data Encryption (TDE) Setup
-- Fully Idempotent (No Dynamic SQL)
-- ==========================================

-- Step 1: Ensure Database Master Key exists in master
USE master;
IF NOT EXISTS (SELECT * FROM sys.symmetric_keys WHERE name = '##MS_DatabaseMasterKey##')
BEGIN
    CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'Password#123';
END
ELSE
BEGIN
    PRINT 'Database Master Key already exists.';
END;
GO

-- Step 2: Ensure Server Certificate exists
IF NOT EXISTS (SELECT * FROM sys.certificates WHERE name = 'PEF10ServerCertificate')
BEGIN
    CREATE CERTIFICATE PEF10ServerCertificate
        WITH SUBJECT = 'TDE Certificate';
END
ELSE
BEGIN
    PRINT 'Server Certificate already exists.';
END;
GO

-- Step 3: Ensure Database Encryption Key (DEK) exists in target database
USE InventoryManagerDB_1001;
IF NOT EXISTS (
    SELECT * FROM sys.dm_database_encryption_keys 
    WHERE database_id = DB_ID('InventoryManagerDB_1001')
)
BEGIN
    PRINT 'Creating Database Encryption Key (DEK)...';
    CREATE DATABASE ENCRYPTION KEY
        WITH ALGORITHM = AES_256
        ENCRYPTION BY SERVER CERTIFICATE PEF10ServerCertificate;
END
ELSE
BEGIN
    PRINT 'Database Encryption Key (DEK) already exists.';
END;
GO

-- Step 4: Enable encryption if not already enabled
IF NOT EXISTS (
    SELECT * FROM sys.dm_database_encryption_keys 
    WHERE database_id = DB_ID('InventoryManagerDB_1001') 
      AND encryption_state = 3
)
BEGIN
    ALTER DATABASE InventoryManagerDB_1001 SET ENCRYPTION ON;
END
ELSE
BEGIN
    PRINT 'TDE is already enabled on this database.';
END;
GO
```  

