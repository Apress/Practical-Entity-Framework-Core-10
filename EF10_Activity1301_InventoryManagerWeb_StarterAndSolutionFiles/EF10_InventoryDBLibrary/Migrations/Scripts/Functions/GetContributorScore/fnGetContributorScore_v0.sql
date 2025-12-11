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
