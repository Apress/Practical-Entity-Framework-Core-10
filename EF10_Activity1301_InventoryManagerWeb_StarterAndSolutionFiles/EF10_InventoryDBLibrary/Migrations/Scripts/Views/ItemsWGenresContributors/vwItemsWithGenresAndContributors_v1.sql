CREATE OR ALTER VIEW [dbo].[vwItemsWithGenresAndContributors]
AS
WITH   GenreAgg
AS     (SELECT   ig.ItemId,
                 STRING_AGG(g.GenreName, ', ') AS Genres
        FROM     ItemGenres AS ig
                 INNER JOIN
                 Genres AS g
                 ON g.Id = ig.GenreId
        GROUP BY ig.ItemId),
       ContrAgg
AS     (SELECT   ic.ItemId,
                 STRING_AGG(ctr.ContributorName, ', ') AS Contributors
        FROM     ItemContributors AS ic
                 INNER JOIN
                 Contributors AS ctr
                 ON ctr.Id = ic.ContributorId
        GROUP BY ic.ItemId)
SELECT i.Id AS ItemId,
       i.Name AS ItemName,
       c.CategoryName AS Category,
       ISNULL(ga.Genres, 'No Genres') AS GenresCsv,
       ISNULL(ca.Contributors, 'No Contributors') AS ContributorsCsv,
       COALESCE (i.Quantity, 0) * COALESCE (i.CurrentValue, 0) AS TotalValue
FROM   Items AS i
       INNER JOIN
       Categories AS c
       ON c.Id = i.CategoryId
       LEFT OUTER JOIN
       GenreAgg AS ga
       ON ga.ItemId = i.Id
       LEFT OUTER JOIN
       ContrAgg AS ca
       ON ca.ItemId = i.Id;
