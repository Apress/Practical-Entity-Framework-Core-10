CREATE OR ALTER FUNCTION dbo.fnTopValuedItems(@TopCount INT)
RETURNS TABLE
AS
RETURN
(
    SELECT TOP (@TopCount)
           i.Id as ItemId, 
           i.Name as ItemName, 
           (i.Quantity * i.CurrentValue) AS TotalValue
    FROM Items i
    ORDER BY TotalValue DESC
);
