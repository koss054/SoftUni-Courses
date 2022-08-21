CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[DailyRate] INT NOT NULL,
	[WeeklyRate] INT NOT NULL,
	[MonthlyRate] INT NOT NULL,
	[WeekendRate] INT NOT NULL
)

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
	VALUES
('Coupe', 6, 40, 160, 10),
('Sedan', 8, 45, 170, 12),
('Hatchback', 5, 30, 110, 7)

CREATE TABLE [Cars] (
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] VARCHAR(8) NOT NULL,
	[Manufacturer] VARCHAR(20) NOT NULL,
	[Model] VARCHAR(20) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Doors] INT NOT NULL,
	[Picture] VARBINARY(MAX),
	[Condition] VARCHAR(20) NOT NULL,
	[Available] BIT NOT NULL
)

INSERT INTO [Cars] ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Condition], [Available])
	VALUES
('TX9991XT', 'Honda', 'S2000', 1998, 1, 2, 'new', 1),
('B 2231BP', 'Nissan', '350z', 2002, 2, 4, 'used', 0),
('VT3346TV', 'Toyota', 'Supra', 1999, 1, 2, 'used', 1)

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[Title] VARCHAR(30) NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title])
	VALUES
('Kaloyan', 'Georgiev', 'Manager'),
('Yordan', 'Dimov', 'CEO'),
('Krasimir', 'Yovchev', 'Head Staff')

CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] VARCHAR(60) NOT NULL,
	[Address] VARCHAR(100),
	[City] VARCHAR(30),
	[ZIPCode] VARCHAR(10),
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Customers] ([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
	VALUES
(22242, 'Konstantin Stoilov', NULL, 'Varna', '9010', 'Shops often from us'),
(33345, 'Gospodin Petkov', 'ul. Frenska Katedra 22', 'Selo Vyobrajenie', '9999', 'First time customer'),
(22242, 'Diyana Svetoslavova', NULL, NULL, NULL, NULL)

CREATE TABLE [RentalOrders] (
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers] ([Id]) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars] ([Id]) NOT NULL,
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATETIME2 NOT NULL,
	[EndDate] DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] INT NOT NULL,
	[TaxRate] INT NOT NULL,
	[OrderStatus] BIT NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [RentalOrders] 
	([EmployeeId], [CustomerId], [CarId], [TankLevel], 
	[KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], 
	[EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus])
	VALUES
(1, 1, 1, 100, 0, 1000, 1000, '2020-12-23 15:40:45', '2020-12-27 15:40:45', 4, 20, 5, 'true'),
(2, 2, 2, 100, 20000, 30000, 10000, '2020-12-23 15:40:45', '2020-12-27 15:40:45', 4, 20, 5, 'true'),
(3, 3, 3, 50, 0, 500, 500, '2020-12-23 15:40:45', '2020-12-27 15:40:45', 4, 20, 5, 'true')

SELECT *
	FROM [RentalOrders]

