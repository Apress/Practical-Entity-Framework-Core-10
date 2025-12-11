# Listing 7-2 - A Table-Valued Function

THe following code shows the definition used to create table valued function.

## The code

```T-SQL
CREATE FUNCTION dbo.fnTopValuedItems(@TopCount INT)
RETURNS TABLE
AS
RETURN
(
    SELECT TOP (@TopCount)
           i.Id, 
           i.Name, 
           (i.Quantity * i.CurrentValue) AS TotalValue
    FROM Items i
    ORDER BY TotalValue DESC
);
```  