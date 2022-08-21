CREATE DATABASE [Bitbucket]
USE [Bitbucket]

--Problem 1
CREATE TABLE [Users] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE [Repositories] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [RepositoriesContributors] (
	[RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id]) NOT NULL,
	[ContributorId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL,
	PRIMARY KEY ([RepositoryId], [ContributorId])
)

CREATE TABLE [Issues] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(255) NOT NULL,
	[IssueStatus] VARCHAR(6) NOT NULL,
	[RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id]) NOT NULL,
	[AssigneeId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL
)

CREATE TABLE [Commits] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	[IssueId] INT FOREIGN KEY REFERENCES [Issues]([Id]),
	[RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id]) NOT NULL,
	[ContributorId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL
)

CREATE TABLE [Files] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[Size] DECIMAL(15, 2) NOT NULL,
	[ParentId] INT FOREIGN KEY REFERENCES [Files]([Id]),
	[CommitId] INT FOREIGN KEY REFERENCES [Commits]([Id]) NOT NULL
)

--Problem 2
INSERT INTO [Files]([Name], [Size], [ParentId], [CommitId])
     VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO [Issues]([Title], [IssueStatus], [RepositoryId], [AssigneeId])
     VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

--Problem 3
UPDATE [Issues]
   SET [IssueStatus] = 'closed'
 WHERE [AssigneeId] = 6

--Problem 4
SELECT *
  FROM [RepositoriesContributors]
    AS [rc]
  JOIN [Repositories]
    AS [r]
	ON [r].[Id] = [rc].[RepositoryId]

DELETE
  FROM [RepositoriesContributors]
 WHERE [RepositoryId] = 3

DELETE
  FROM [Issues]
 WHERE [RepositoryId] = 3

--Problem 5
  SELECT [Id]
       , [Message]
	   , [RepositoryId]
	   , [ContributorId]
    FROM [Commits]
ORDER BY [Id], [Message], [RepositoryId], [ContributorId]

--Problem 6
  SELECT [Id]
       , [Name]
  	   , [Size]
    FROM [Files]
   WHERE [Size] > 1000
     AND [Name] LIKE '%.html'
ORDER BY [Size] DESC, [Id], [Name]

--Problem 7
   SELECT [i].[Id]
        , CONCAT([u].[Username], ' : ', [i].[Title])
	   AS [IssueAssignee]
     FROM [Issues]
	   AS [i]
LEFT JOIN [Users]
       AS [u]
	   ON [u].[Id] = [i].[AssigneeId]
 ORDER BY [i].[Id] DESC, [i].[AssigneeId]

--Problem 8
  SELECT [f1].[Id]
       , [f1].[Name]
	   , CONCAT([f1].[Size], 'KB')
      AS [Size]
    FROM [Files]
      AS [f1]
   WHERE NOT EXISTS (
	                  SELECT 1
					    FROM [Files]
						  AS [f2]
					   WHERE [f2].[ParentId] = [f1].[Id]
	                 )
ORDER BY [f1].[Id], [f1].[Name], [f1].[Size] DESC

--Problem 9
SELECT TOP (5)
           [r].[Id]
		 , [r].[Name]
		 , COUNT([r].[Name])
		AS [Commits]
      FROM [Repositories]
	    AS [r]
 LEFT JOIN [Commits]
        AS [c]
		ON [r].[Id] = [c].[RepositoryId]
	  JOIN [RepositoriesContributors]
	    AS [rc]
		ON [rc].[RepositoryId] = [r].[Id]
  GROUP BY [r].[Id], [r].[Name]
  ORDER BY [Commits] DESC, [r].[Id], [r].[Name]

--Problem 10
   SELECT [u].[Username]
        , AVG([f].[Size])
	   AS [Size]
     FROM [Users] 
       AS [u]
LEFT JOIN [Commits] 
       AS [c]
  	   ON [c].[ContributorId] = [u].[Id]
	 JOIN [Files]
	   AS [f]
	   ON [f].[CommitId] = [c].[Id]
 GROUP BY [u].[Username]
 ORDER BY [Size] DESC, [u].[Username]

--Problem 11
GO

CREATE FUNCTION [udf_AllUserCommits](@username VARCHAR(30))
RETURNS INT AS
BEGIN
	DECLARE @userId INT
	SET @userId = (
		SELECT [Id]
		  FROM [Users]
		 WHERE [Username] = @username
	 )

	 DECLARE @userCommitsCount INT
	 SET @userCommitsCount = (
		SELECT COUNT([Id])
		  FROM [Commits]
		 WHERE [ContributorId] = @userId
	 )

	 RETURN @userCommitsCount
END

GO

SELECT [dbo].[udf_AllUserCommits]('UnderSinduxrein')

--Problem 12
GO

CREATE PROCEDURE [usp_SearchForFiles] @fileExtension VARCHAR(15)
AS
	SELECT [Id]
	     , [Name]
		 , CONCAT([Size], 'KB')
		AS [Size]
	  FROM [Files]
	 WHERE [Name] LIKE '%' + @fileExtension

GO

EXEC usp_SearchForFiles 'txt'