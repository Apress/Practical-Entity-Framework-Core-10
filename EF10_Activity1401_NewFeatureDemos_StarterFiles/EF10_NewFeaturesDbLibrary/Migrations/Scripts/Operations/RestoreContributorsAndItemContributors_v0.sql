DELETE FROM dbo.ItemContributors;
DELETE FROM dbo.Contributors;

SET IDENTITY_INSERT dbo.Contributors ON;
INSERT dbo.Contributors (Id, ContributorName, IsActive, [Address])
SELECT [Id],[ContributorName],[IsActive], null
FROM dbo.ContributorsBackup_ch14;
SET IDENTITY_INSERT dbo.Contributors OFF;

SET IDENTITY_INSERT dbo.ItemContributors ON;
INSERT dbo.ItemContributors (Id, ItemId, ContributorId, IsActive, ContributorType)
SELECT [Id],[ItemId],[ContributorId],IsActive,[ContributorType]
FROM dbo.ItemContributorsBackup_ch14;
SET IDENTITY_INSERT dbo.ItemContributors OFF;
