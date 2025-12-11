# Listing 7-16: The SQL to create the new function `fnGetContributorScore`

Use this code in your flat script file to create the function via a migration

## The T-SQL to create the function

Add the script below to the new file `fnGetContributorScore_v0.sql` in the folder `EF10_InventoryDBLibrary/Migrations/Scripts/Functions/GetContributorScore`.

```sql
CREATE OR ALTER FUNCTION dbo.fnGetContributorScore
(
    @ContributorId INT
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @Score DECIMAL(18,2);

    SELECT 
        @Score = (COUNT(DISTINCT i.Id) * AVG(i.CurrentValue)) +
                    (SUM(CASE WHEN i.Quantity < 2 THEN 5 ELSE 0 END))
    FROM Items i
    INNER JOIN ItemContributors ic ON i.Id = ic.ItemId
    WHERE ic.ContributorId = @ContributorId;

    RETURN @Score;
END
```  
