CREATE TABLE [Users](
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 9000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT,
	CHECK ([IsDeleted] = 'true' or [IsDeleted] = 'false')
)


INSERT INTO [Users] ([Username], [Password], [IsDeleted])
	VALUES
('skull054', 'lolomg', 'false'),
('koss054', 'omglol', 'false'),
('ThaSkull', 'veryCl3v3rP455w0rd', 'true'),
('SKOO', 'csMANQK', 'false'),
('[BG]Skull054', 'gtaSAMP', 'true')

SELECT * 
	FROM [Users]

ALTER TABLE [Users]
	DROP CONSTRAINT [PK__Users__3214EC07475B1C34]

ALTER TABLE [Users]
	ADD CONSTRAINT PK_Users PRIMARY KEY ([Id], [Username])

ALTER TABLE [Users]
	ADD CONSTRAINT CK_PassLength CHECK (DATALENGTH([Password]) >= 5)

INSERT INTO [Users] ([Username], [Password], [IsDeleted])
	VALUES
('BADUSER', '22222', 'true')

ALTER TABLE [Users]
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR [LastLoginTime]

INSERT INTO [Users] ([Username], [Password], [IsDeleted])
	VALUES
('DEFAULTUSER', '22222', 'true')
SELECT *
	FROM [Users]
