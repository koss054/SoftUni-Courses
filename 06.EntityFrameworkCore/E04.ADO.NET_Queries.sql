--Problem 2
  SELECT [v].[Name]
       , COUNT([mv].[MinionId]) AS [MinionsCount]
    FROM [MinionsVillains] AS [mv]
    JOIN [Villains] AS [v]
      ON [v].[Id] = [mv].VillainId
GROUP BY [v].[Id], [v].[Name]
  HAVING COUNT([mv].[MinionId]) > 3
ORDER BY COUNT([mv].[MinionId])

--Problem 3
SELECT [Name]
  FROM [Villains]
 WHERE [Id] = 1

   SELECT [m].[Name]
        , [m].[Age]
     FROM [MinionsVillains] AS [mv]
LEFT JOIN [Minions] AS [m]
       ON [m].[Id] = [mv].[MinionId]
	WHERE [mv].VillainId = 1
 ORDER BY [m].[Name]

--Problem 4
SELECT [Id]
  FROM [Towns]
 WHERE [Name] = 'Grubenfan'

INSERT INTO [Towns]([Name])
     VALUES
('Name')

SELECT [Id]
  FROM [Villains]
 WHERE [Name] = 'Gru'

SELECT *
  FROM [EvilnessFactors] -- Level 'Evil' is with Id 4

INSERT INTO [Villains]([Name], [EvilnessFactorId])
     VALUES
('Name', 4)

INSERT INTO [Minions]([Name], [Age], [TownId])
     VALUES
('Name', 10, 1)

SELECT [Id]
  FROM [Minions]
 WHERE [Name] = 'Name' AND [Age] = 10 AND TownId = 1

INSERT INTO [MinionsVillains]([MinionId], [VillainId])
     VALUES
(1, 1)

--Problem 5
SELECT [Id]
  FROM [Countries]
 WHERE [Name] = 'Bulgaria'

UPDATE [Towns]
   SET [Name] = UPPER([Name])
 WHERE [CountryCode] = 1

SELECT [Name]
  FROM [Towns]
 WHERE [CountryCode] = 1

--Problem 6
SELECT [Name]
  FROM [Villains]
 WHERE [Id] = 1

DELETE FROM [MinionsVillains]
      WHERE [VillainId] = 1

DELETE FROM [Villains]
      WHERE [Id] = 1

--Problem 9
GO

CREATE PROCEDURE [usp_GetOlder] @minionId INT
AS
	UPDATE [Minions]
	   SET [Age] += 1
	 WHERE [Id] = @minionId

GO

EXEC [dbo].[usp_GetOlder] 1

SELECT CONCAT([Name], ' - ', [Age], ' years old')
    AS [Output]
  FROM [Minions]
 WHERE [Id] = 1