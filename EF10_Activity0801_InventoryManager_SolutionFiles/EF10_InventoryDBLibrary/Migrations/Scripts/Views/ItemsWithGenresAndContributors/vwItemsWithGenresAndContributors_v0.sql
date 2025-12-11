--listing 7-28
CREATE OR ALTER VIEW [dbo].[vwItemsWithGenresAndContributors]
AS

WITH GenreAgg AS (
    SELECT ig.ItemId,
           STRING_AGG(g.GenreName, ', ') AS Genres
    FROM ItemGenres ig
    JOIN Genres g ON g.Id = ig.GenreId
    GROUP BY ig.ItemId
),
ContrAgg AS (
    SELECT ic.ItemId,
           STRING_AGG(ctr.ContributorName, ', ') AS Contributors
    FROM ItemContributors ic
    JOIN Contributors ctr ON ctr.Id = ic.ContributorId
    GROUP BY ic.ItemId
)
SELECT
    i.Id AS ItemId,
    i.Name AS ItemName,
    c.CategoryName,
    ISNULL(ga.Genres, '') Genres,
    ISNULL(ca.Contributors, '') Contributors,
    COALESCE(i.Quantity, 0) * COALESCE(i.CurrentValue, 0) AS TotalValue
FROM Items i
JOIN Categories c ON c.Id = i.CategoryId
LEFT JOIN GenreAgg ga ON ga.ItemId = i.Id
LEFT JOIN ContrAgg ca on ca.ItemId = i.Id