CREATE OR ALTER FUNCTION dbo.fnCalculateItemValue (@ItemId INT)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @Value DECIMAL(18,2);

    SELECT @Value = (Quantity * CurrentValue) *
                    CASE WHEN IsOnSale = 1 THEN 0.9 ELSE 1 END
    FROM Items
    WHERE Id = @ItemId;

    RETURN @Value;
END
