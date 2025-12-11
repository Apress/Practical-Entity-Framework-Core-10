# Listing 7-15: Testing the new scalar function

Test to make sure the function code will work as expected

## The Code to use for testing before creating the GetContributorScore function

Here is the code to use for testing.

```sql
DECLARE @Score DECIMAL(18,2);
DECLARE @ContributorId INT = 1

SELECT 
    (COUNT(DISTINCT i.Id) * AVG(i.CurrentValue)) +
                (SUM(CASE WHEN i.Quantity < 2 THEN 5 ELSE 0 END))
FROM Items i
INNER JOIN ItemContributors ic ON i.Id = ic.ItemId
WHERE ic.ContributorId = @ContributorId;
```  