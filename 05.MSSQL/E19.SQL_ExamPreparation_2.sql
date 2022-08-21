CREATE DATABASE [CigarShop]
USE [CigarShop]

--Problem 1
CREATE TABLE [Sizes] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Length] INT CHECK([Length] BETWEEN 10 AND 25) NOT NULL,
	[RingRange] DECIMAL(2, 1) CHECK([RingRange] BETWEEN 1.5 AND 7.5) NOT NULL
)

CREATE TABLE [Tastes] (
	[Id] INT PRIMARY KEY IDENTITY,
	[TasteType] VARCHAR(20) NOT NULL,
	[TasteStrength] VARCHAR(15) NOT NULL,
	[ImageURL] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Brands] (
	[Id] INT PRIMARY KEY IDENTITY,
	[BrandName] VARCHAR(30) UNIQUE NOT NULL,
	[BrandDescription] VARCHAR(MAX)
)

CREATE TABLE [Cigars] (
	[Id] INT PRIMARY KEY IDENTITY,
	[CigarName] VARCHAR(80) NOT NULL,
	[BrandId] INT FOREIGN KEY REFERENCES [Brands]([Id]) NOT NULL,
	[TastId] INT FOREIGN KEY REFERENCES [Tastes]([Id]) NOT NULL,
	[SizeId] INT FOREIGN KEY REFERENCES [Sizes]([Id]) NOT NULL,
	[PriceForSingleCigar] MONEY NOT NULL,
	[ImageURL] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Addresses] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Town] VARCHAR(30) NOT NULL,
	[Country] NVARCHAR(30) NOT NULL,
	[Streat] NVARCHAR(100) NOT NULL,
	[ZIP] VARCHAR(20) NOT NULL
)

CREATE TABLE [Clients] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id]) NOT NULL
)

CREATE TABLE [ClientsCigars] (
	[ClientId] INT FOREIGN KEY REFERENCES [Clients]([Id]) NOT NULL,
	[CigarId] INT FOREIGN KEY REFERENCES [Cigars]([Id]) NOT NULL,
	PRIMARY KEY ([ClientId], [CigarId])
)

--Problem 2
INSERT INTO [Cigars]([CigarName], [BrandId], [TastId], [SizeId], [PriceForSingleCigar], [ImageURL])
     VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town, Country, Streat, ZIP)
     VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

--Problem 3
UPDATE [Cigars]
   SET [PriceForSingleCigar] += ([PriceForSingleCigar] * 0.2)
 WHERE [TastId] = 1

UPDATE [Brands]
   SET [BrandDescription] = 'New description'
 WHERE [BrandDescription] IS NULL

--Problem 4
DELETE FROM [Clients]
      WHERE [AddressId] IN (
								SELECT [c].[AddressId]
								  FROM [Clients] AS [c]
								  JOIN [Addresses] AS [a]
								    ON [a].[Id] = [c].[AddressId]
								 WHERE [a].[Country] LIKE 'C%'
						   )

DELETE FROM [Addresses]
      WHERE [Country] LIKE 'C%'

--Problem 5
  SELECT [CigarName]
       , [PriceForSingleCigar]
  	   , [ImageURL]
    FROM [Cigars]
ORDER BY [PriceForSingleCigar], [CigarName] DESC

--Problem 6
  SELECT [c].[Id]
       , [c].[CigarName]
  	   , [c].[PriceForSingleCigar]
  	   , [t].[TasteType]
  	   , [t].[TasteStrength]
    FROM [Cigars] AS [c]
    JOIN [Tastes] AS [t]
      ON [t].[Id] = [c].[TastId]
   WHERE [t].[TasteType] = 'Earthy'
      OR [t].[TasteType] = 'Woody'
ORDER BY [c].[PriceForSingleCigar] DESC

--Problem 7
  SELECT [Id]
       , CONCAT([FirstName], ' ', [LastName]) AS [ClientName]
       , [Email]
    FROM [Clients]
   WHERE [Id] NOT IN (
					      SELECT [c].[Id]
					        FROM [ClientsCigars] AS [cc]
					   LEFT JOIN [Clients] AS [c]
					          ON [c].[Id] = [cc].[ClientId]
					 )
ORDER BY [ClientName]

--Problem 8
SELECT TOP (5) [c].[CigarName]
             , [c].[PriceForSingleCigar]
			 , [c].[ImageURL]
         FROM [Cigars] AS [c]
         JOIN [Sizes] AS [s]
           ON [s].[Id] = [c].[SizeId]
        WHERE [s].[Length] >= 12 AND ([c].[CigarName] LIKE '%ci%'
           OR [c].[PriceForSingleCigar] > 50) AND [s].[RingRange] > 2.55
     ORDER BY [c].[CigarName], [c].[PriceForSingleCigar] DESC

--Problem 9
  SELECT CONCAT([c].[FirstName], ' ', [c].[LastName]) AS [FullName]
       , [a].[Country]
  	   , [a].[ZIP]
  	   , CONCAT('$', MAX([cig].[PriceForSingleCigar])) AS [CigarPrice]
    FROM [Clients] AS [c]
    JOIN [Addresses] AS [a]
      ON [a].[Id] = [c].[AddressId]
    JOIN [ClientsCigars] AS [cc]
      ON [cc].[ClientId] = [c].[Id]
    JOIN [Cigars] AS [cig]
      ON [cig].[Id] = [cc].[CigarId]
   WHERE ISNUMERIC([ZIP]) = 1
GROUP BY [c].[FirstName], [c].[LastName], [a].[Country], [a].[ZIP]

--Problem 10
   SELECT  [cl].[LastName]
        , AVG([s].[Length]) AS [CiagrLength]
	    , CEILING(AVG([s].[RingRange])) AS [CiagrRingRange]
    FROM [ClientsCigars] AS [cc]
LEFT JOIN [Cigars] AS [c]
	   ON [c].[Id] = [cc].[CigarId]
LEFT JOIN [Sizes] AS [s]
	   ON [s].[Id] = [c].[SizeId]
LEFT JOIN [Clients] AS [cl]
	   ON [cl].[Id] = [cc].[ClientId]
    WHERE [cl].[LastName] IN (
								SELECT DISTINCT [cl].[LastName]
								           FROM [Clients]
                             )
 GROUP BY [cl].[LastName]
 ORDER BY [CiagrLength] DESC

--Problem 11
GO

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @clientCigarCount INT

	SET @clientCigarCount = (
		SELECT COUNT (*)
		  FROM ClientsCigars
		 WHERE ClientId IN (
			SELECT Id
			  FROM Clients
			 WHERE FirstName = @name
		 )
	)

	RETURN @clientCigarCount
END

go

SELECT [dbo].udf_ClientWithCigars('Irene')

  SELECT ClientId
       , COUNT(CigarId)
    FROM ClientsCigars
GROUP BY ClientId

GO

--Problem 12
GO

CREATE PROC usp_SearchByTaste @taste VARCHAR(20)
AS
	  SELECT c.CigarName
	       , CONCAT('$', c.PriceForSingleCigar) AS Price
	  	   , t.TasteType
	  	   , b.BrandName
	  	   , CONCAT(s.Length, ' cm') AS CigarLength
	  	   , CONCAT(CAST(s.RingRange AS DECIMAL(5, 2)), ' cm') AS CigarRingRange
	    FROM Cigars AS c
	    JOIN Tastes AS t
	      ON t.Id = c.TastId
	    JOIN Brands AS b
	      ON b.Id = c.BrandId
	    JOIN Sizes AS s
	      ON s.Id = c.SizeId
	   WHERE t.TasteType = @taste
	ORDER BY CigarLength, CigarRingRange DESC

GO

EXEC [dbo].[usp_SearchByTaste] 'Woody'