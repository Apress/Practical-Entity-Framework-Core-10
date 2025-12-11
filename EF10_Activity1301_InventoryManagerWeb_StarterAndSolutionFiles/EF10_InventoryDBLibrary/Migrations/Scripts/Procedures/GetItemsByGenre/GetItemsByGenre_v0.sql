CREATE OR ALTER PROCEDURE [dbo].[GetItemsByGenre] 
    @genreName NVARCHAR(50),
    @isActive BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        i.Id AS ItemId,                 
        i.Name AS ItemName,             
        g.Id AS GenreId, 
        i.Description AS ItemDescription,
        g.GenreName,
        i.IsActive
    FROM Genres g
    INNER JOIN ItemGenres ig on g.id = ig.GenreId
    INNER JOIN Items i ON ig.ItemId = i.Id
    WHERE g.GenreName = @genreName
    AND i.IsActive = @isActive
END