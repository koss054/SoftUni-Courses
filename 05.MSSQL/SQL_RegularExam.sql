CREATE DATABASE Zoo
USE Zoo

--Problem 1
CREATE TABLE Owners (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes (
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages (
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE Animals (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE AnimalsCages (
	CageId INT FOREIGN KEY REFERENCES Cages(Id) NOT NULL,
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
	PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments (
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES [Animals]([Id]),
	DepartmentId INT FOREIGN KEY REFERENCES [VolunteersDepartments]([Id]) NOT NULL
)

--Problem 2
INSERT INTO Volunteers([Name], PhoneNumber, [Address], AnimalId, DepartmentId)
     VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', NULL, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
     VALUES
('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', NULL, 1),
('Tuatara', '2021-06-30', 2, 4)

--Problem 3
UPDATE Animals
   SET OwnerId = 4
 WHERE OwnerId IS NULL

--Problem 4
DELETE FROM Volunteers
      WHERE DepartmentId = 2

DELETE FROM VolunteersDepartments
      WHERE Id = 2

--Problem 5
  SELECT [Name]
       , PhoneNumber
  	   , [Address]
  	   , AnimalId
  	   , DepartmentId
    FROM Volunteers
ORDER BY [Name], AnimalId, DepartmentId

--Problem 6
SELECT [Name]
     , [at].AnimalType
	 , FORMAT(BirthDate, 'dd.MM.yyyy') AS BirthDate
  FROM Animals AS a
  JOIN AnimalTypes AS [at]
    ON [at].Id = a.AnimalTypeId
ORDER BY [Name]

--Problem 7
SELECT TOP (5) o.[Name] AS Owner
             , COUNT(a.OwnerId) AS CountOfAnimals
          FROM Animals AS a
          JOIN Owners AS o
            ON o.Id = a.OwnerId
      GROUP BY a.OwnerId, o.[Name]
      ORDER BY COUNT(a.OwnerId) DESC, o.[Name]

--Problem 8
  SELECT CONCAT(o.[Name], '-', a.[Name]) AS OwnersAnimals
       , o.PhoneNumber
  	   , ac.CageId
    FROM Animals AS a
    JOIN Owners AS o
      ON o.Id = a.OwnerId
    JOIN AnimalTypes AS [at]
      ON [at].Id = a.AnimalTypeId
    JOIN AnimalsCages AS ac
      ON ac.AnimalId = a.Id
   WHERE [at].AnimalType = 'Mammals'
ORDER BY o.[Name], a.[Name] DESC

--Problem 9
  SELECT [Name]
       , PhoneNumber
  	   , REPLACE(REPLACE([Address], 'Sofia, ', ''), ' Sofia , ', '') AS [Address]
    FROM Volunteers
   WHERE DepartmentId = 2
     AND [Address] LIKE '%Sofia%'
ORDER BY [Name]

--Problem 10
  SELECT a.[Name]
       , YEAR(a.BirthDate) AS BirthYear
  	   , [at].AnimalType
    FROM Animals AS a
    JOIN AnimalTypes AS [at]
      ON [at].Id = a.AnimalTypeId
   WHERE OwnerId IS NULL
     AND AnimalTypeId != 3
     AND DATEDIFF(YEAR, a.BirthDate, '20220101') < 5
ORDER BY a.[Name]

--Problem 11
GO

CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @DepartmentId INT
	SET @DepartmentId = (
		SELECT Id
		  FROM VolunteersDepartments
		 WHERE DepartmentName = @VolunteersDepartment
	)

	DECLARE @VolunteersInDepartmentCount INT
	SET @VolunteersInDepartmentCount = (
		  SELECT COUNT(Id)
		    FROM Volunteers
		GROUP BY DepartmentId
		  HAVING DepartmentId = @DepartmentId
	)

	RETURN @VolunteersInDepartmentCount
END

GO

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

--Problem 12
GO

CREATE PROC usp_AnimalsWithOwnersOrNot @AnimalName VARCHAR(30)
AS
	   SELECT a.[Name]
	        , CASE 
					WHEN a.OwnerId IS NULL THEN 'For adoption'
					ELSE o.Name
			  END AS OwnersName
	     FROM Animals AS a
	LEFT JOIN Owners AS o
	       ON o.Id = a.OwnerId
	    WHERE a.[Name] = @AnimalName

GO

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'