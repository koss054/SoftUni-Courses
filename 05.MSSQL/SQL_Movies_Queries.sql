CREATE DATABASE [Movies]

CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] VARCHAR(75) NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Directors] ([DirectorName], [Notes])
	VALUES
('Michel Afton', NULL),
('Nicolas Cage', 'Also an actor'),
('Pablo Picasso', 'Wat'),
('Ivan Ivanov Ivanov', NULL),
('Gospodin Bob', NULL)

CREATE TABLE [Genres] (
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] VARCHAR(30) NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Genres] ([GenreName], [Notes])
	VALUES
('Horror', NULL),
('Futuristic Horror', 'Experimental'),
('Fantasy', NULL),
('Adventure', NULL),
('Bobeni Priklucheniq', 'Gospodin Bob approved')


CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(30) NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Categories] ([CategoryName], [Notes])
	VALUES
('Family', NULL),
('Everyone', NULL),
('Bob', 'Maybe everyone (?)'),
('PG13', NULL),
('Children', NULL)

CREATE TABLE [Movies] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(75) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] INT NOT NULL,
	[Length] INT NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] INT NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
	VALUES
('A Beany Adventure', 5, 2010, 155, 5, 3, 10, 'Somehow a success'),
('Special Cinema Time', 2, 1999, 123, 3, 2, 8, NULL),
('Rodeo Kitchen', 4, 2001, 136, 2, 4, 6, NULL),
('Pizzaria', 1, 2022, 184, 1, 4, 10, 'bruh'),
('Incredible Time', 3, 120, 23, 3, 3, 9, NULL)

SELECT *
	FROM [Directors]

SELECT *
	FROM [Genres]

SELECT *
	FROM [Categories]

SELECT *
	FROM [Movies]