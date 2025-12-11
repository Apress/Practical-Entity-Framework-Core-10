CREATE OR ALTER PROCEDURE dbo.GetItemsByCategory 
	@categoryName NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT i.*, c.*
	FROM Categories c
	INNER JOIN Items i on c.Id = i.CategoryId
	WHERE c.CategoryName = @categoryName
END