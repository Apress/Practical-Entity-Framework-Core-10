CREATE OR ALTER VIEW [dbo].[vwGetItemDetailSummaries]
AS

WITH GenreAgg AS (
    SELECT ig.ItemId as ItemId,
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
    i.ItemName AS ItemName,
    c.CategoryName,
    ISNULL(ga.Genres, '') as Genres,
    ISNULL(ca.Contributors, '') as Contributors
FROM Items i
JOIN Categories c ON c.Id = i.CategoryId
LEFT JOIN GenreAgg ga ON ga.ItemId = i.Id
LEFT JOIN ContrAgg ca on ca.ItemId = i.Id