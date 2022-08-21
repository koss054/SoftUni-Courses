CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[Title] VARCHAR(20) NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes])
	VALUES
('Stan', 'Stanimirov', 'Receptionist', '5 Years of experience.'),
('Ralitsa', 'Karadjova', 'Front Desk', '1st Year on position.'),
('Mihaela', 'Vasileva', 'Receptionist', NULL)

CREATE TABLE [Customers] (
	[AccountNumber] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[PhoneNumber] VARCHAR(10) NOT NULL,
	[EmergencyName] VARCHAR(50),
	[EmergencyNumber] VARCHAR(10),
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Customers] ([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes])
	VALUES
('Karakhi', 'Vasilievizch', '1234567890', 'Kahi Vazi', '0987654321', 'Regular customer.'),
('Marian', 'Kostov', '0895567891', NULL, NULL, NULL),
('Krasimira', 'Ksenieva', '0888432167', NULL, '0894563456', 'New customer. Tips well.')

CREATE TABLE [RoomStatus] (
	[RoomStatus] VARCHAR(20) PRIMARY KEY,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [RoomStatus] ([RoomStatus], [Notes])
	VALUES
('Occupied', NULL),
('Vacant', 'Clean during cleaning hours.'),
('Reserved', NULL)

CREATE TABLE [RoomTypes] (
	[RoomType] VARCHAR(20) PRIMARY KEY,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [RoomTypes] ([RoomType], [Notes])
	VALUES
('Single Room', NULL),
('Double Room', 'Give two keys.'),
('Apartment', 'Give three keys and inform about max keys per apartment.')

CREATE TABLE [BedTypes] (
	[BedType] VARCHAR(20) PRIMARY KEY,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [BedTypes] ([BedType], [Notes])
	VALUES
('Single Bed', NULL),
('Double Bed', NULL),
('Separateble Bed', 'Inform customers about this bed.')


CREATE TABLE [Rooms] (
	[RoomNumber] INT PRIMARY KEY,
	[RoomType] VARCHAR(20) FOREIGN KEY REFERENCES [RoomTypes] ([RoomType]),
	[BedType] VARCHAR(20) FOREIGN KEY REFERENCES [BedTypes] ([BedType]) NOT NULL,
	[Rate] INT NOT NULL,
	[RoomStatus] VARCHAR(20) FOREIGN KEY REFERENCES [RoomStatus] ([RoomStatus]) NOT NULL,
	[Notes] VARCHAR(MAX)
)


INSERT INTO [Rooms] ([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus], [Notes])
	VALUES
(101, 'Single Room', 'Single Bed', 50, 'Vacant', 'Fix the AC.'),
(223, 'Double Room', 'Double Bed', 150, 'Reserved', 'Sea view.'),
(1040, 'Apartment', 'Double Bed', 150, 'Occupied', 'Replace the Seperatable Bed with a funtional one.')

CREATE TABLE [Payments] (
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
	[PaymentDate] DATETIME2 DEFAULT GETDATE(),
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers] ([AccountNumber]) NOT NULL,
	[FirstDateOccupied] DATETIME2 DEFAULT GETDATE(),
	[LastDateOccupied] DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[AmountCharged] INT NOT NULL,
	[TaxRate] INT NOT NULL,
	[TaxAmount] INT NOT NULL,
	[PaymentTotal] INT NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Payments] ([EmployeeId], [AccountNumber], [LastDateOccupied], [TotalDays], [AmountCharged], [TaxRate], [TaxAmount], [PaymentTotal], [Notes])
	VALUES
(1, 1, '2022-06-01 00:00:00.0000000', 11, 45, 10, 5, 50, NULL),
(2, 2, '2022-06-01 00:00:00.0000000', 11, 135, 10, 25, 150, NULL),
(3, 3, '2022-06-01 00:00:00.0000000', 11, 135, 10, 25, 150, NULL)

CREATE TABLE [Occupancies] (
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
	[DateOccupied] DATETIME2 DEFAULT GETDATE(),
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers] ([AccountNumber]) NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms] ([RoomNumber]) NOT NULL,
	[RateApplied] INT NOT NULL,
	[PhoneCharge] INT NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Occupancies] ([EmployeeId], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge], [Notes])
	VALUES
(1, 1, 101, 50, 0, 'No phone in room.'),
(2, 2, 223, 150, 0, 'No phone in room.'),
(3, 3, 1040, 150, 0, 'No phone in room.')