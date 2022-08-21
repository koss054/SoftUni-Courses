--Forgot to save the previous solutions cuz I got fked up
--Problem 3
CREATE TABLE [Students](
	[StudentID] INT NOT NULL,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [Exams](
	[ExamID] INT NOT NULL,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [StudentsExams](
	[StudentID] INT NOT NULL,
	[ExamID] INT NOT NULL
)

INSERT INTO [Students]([StudentID], [Name])
	 VALUES
(1, 'Mila'),
(2, 'Toni'),
(3, 'Ron')

INSERT INTO [Exams]([ExamID], [Name])
	 VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO [StudentsExams]([StudentID], [ExamID])
	 VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

   ALTER TABLE [Students]
ADD CONSTRAINT [PK_StudentID]
   PRIMARY KEY ([StudentID])

   ALTER TABLE [Exams]
ADD CONSTRAINT [PK_ExamID]
   PRIMARY KEY ([ExamID])

   ALTER TABLE [StudentsExams]
ADD CONSTRAINT [PK_StudentID_ExamID]
   PRIMARY KEY ([StudentID], [ExamID])

   ALTER TABLE [StudentsExams]
ADD CONSTRAINT [FK_StudentsExams_StudentID]
   FOREIGN KEY ([StudentID])
    REFERENCES [Students]([StudentID])

   ALTER TABLE [StudentsExams]
ADD CONSTRAINT [FK_StudentsExams_ExamID]
   FOREIGN KEY ([ExamID])
    REFERENCES [Exams]([ExamID])

--Problem 4
CREATE TABLE [Teachers](
	[TeacherID] INT NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	[ManagerID] INT
)

   ALTER TABLE [Teachers]
ADD CONSTRAINT [PK_TeacherID]
   PRIMARY KEY ([TeacherID])

   ALTER TABLE [Teachers]
ADD CONSTRAINT [FK_ManagerID_TeacherID]
   FOREIGN KEY ([ManagerID])
    REFERENCES [Teachers]([TeacherID])


--Problem 5
CREATE TABLE [Cities](
	[CityID] INT PRIMARY KEY,
	[Name]   VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY,
	[Name]		 VARCHAR(50) NOT NULL,
	[Birthday]	 DATE,
	[CityID]	 INT FOREIGN KEY REFERENCES [Cities]([CityID]) NOT NULL
)

CREATE TABLE [Orders](
	[OrderID]    INT PRIMARY KEY,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID]) NOT NULL
)

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY,
	[Name]		 VARCHAR(50) NOT NULL
)

CREATE TABLE [Items](
	[ItemID]	 INT PRIMARY KEY,
	[Name]		 VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID]) NOT NULL
)

CREATE TABLE [OrderItems](
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]),
	[ItemID]  INT FOREIGN KEY REFERENCES [Items]([ItemID]),
	CONSTRAINT [PK_OrderItems] PRIMARY KEY ([OrderID], [ItemID])
)

--Problem 6
--CREATE DATABASE [University]
--USE [University]
CREATE TABLE [Majors](
	[MajorID] INT NOT NULL,
	[Name] VARCHAR(50)
	CONSTRAINT [PK_Majors] PRIMARY KEY([MajorID])
)

CREATE TABLE [Students](
	[StudentID]     INT NOT NULL,
	[StudentNumber] INT NOT NULL,
	[StudentName]   VARCHAR(50),
	[MajorID]		INT NOT NULL,
	CONSTRAINT [PK_Students] PRIMARY KEY([StudentID]),
	CONSTRAINT [FK_Students_MajorsID] FOREIGN KEY ([MajorID]) REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Subjects](
	[SubjectID]   INT NOT NULL,
	[SubjectName] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Subjects] PRIMARY KEY([SubjectID])
)

CREATE TABLE [Agenda](
	[StudentID] INT NOT NULL,
	[SubjectID] INT NOT NULL,
	CONSTRAINT [PK_Agenda] PRIMARY KEY([StudentID], [SubjectID]),
	CONSTRAINT [FK_StudentID_Students] FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID]),
	CONSTRAINT [FK_SubjectID_Subjects] FOREIGN KEY ([SubjectID]) REFERENCES [Subjects]([SubjectID])
)

CREATE TABLE [Payments](
	[PaymentID]     INT NOT NULL,
	[PaymentDate]   DATE NOT NULL,
	[PaymentAmount] INT NOT NULL,
	[StudentID]		INT NOT NULL,
	CONSTRAINT [PK_Payments] PRIMARY KEY([PaymentID]),
	CONSTRAINT [FK_Payments_Students] FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID])
)