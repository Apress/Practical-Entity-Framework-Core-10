# Listing 10-12: Query the items table

See what the current table looks like with encrypted columns, data should be null on the `PIINumber` until running 10-13, then come back and run again to see `encrypted` column data.

## The SQL

Use this SQL query to see the data quickly:

```sql
SELECT Id,Name, PIINumberBackup, PIINumber FROM ITEMS
````  