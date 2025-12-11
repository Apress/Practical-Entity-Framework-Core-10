CREATE OR ALTER VIEW vwContributorsItems
AS
SELECT 
    ctr.Id AS ContributorId,
    ctr.ContributorName,
    STRING_AGG(i.Name, ', ') AS ItemTitles
FROM Contributors ctr
INNER JOIN ItemContributors ic ON ic.ContributorId = ctr.Id
INNER JOIN Items i ON i.Id = ic.ItemId
GROUP BY ctr.Id, ctr.ContributorName;