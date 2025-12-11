CREATE OR ALTER PROCEDURE [dbo].[GetItemsByCategory] 
    @categoryName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        i.Id AS Id,                 
        i.Name AS Name,             
        i.CategoryId AS CategoryId, 
        c.CategoryName AS CategoryName,
        i.Description,
        i.Notes,
        i.IsActive,
        i.IsOnSale,
        i.PurchasePrice,
        i.Quantity
    FROM Categories c
    INNER JOIN Items i ON c.Id = i.CategoryId
    WHERE c.CategoryName = @categoryName
END
GO