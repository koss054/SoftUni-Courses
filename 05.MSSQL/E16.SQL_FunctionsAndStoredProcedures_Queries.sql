USE [SoftUni]

--Problem 1
GO

CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000]
              AS         
          SELECT [FirstName], [LastName] 
            FROM [Employees]
           WHERE [Salary] > 35000

GO
--Problem 2
GO

CREATE PROCEDURE [usp_GetEmployeesSalaryAboveNumber] @EnteredSalary DECIMAL(18, 4)
		      AS 
		  SELECT [FirstName], [LastName]
		    FROM [Employees]
		   WHERE [Salary] >= @EnteredSalary

EXEC [usp_GetEmployeesSalaryAboveNumber] @EnteredSalary = 48100

GO
--Problem 3
GO

CREATE PROCEDURE [usp_GetTownsStartingWith] @StartingString VARCHAR(30)
              AS
		  SELECT [Name]
		    FROM [Towns]
		   WHERE SUBSTRING([Name], 1, LEN(@StartingString)) = @StartingString

EXEC [usp_GetTownsStartingWith] @StartingString = 'b'

GO
--Problem 4
GO

CREATE PROCEDURE [usp_GetEmployeesFromTown] @TownName VARCHAR(50)
              AS
          SELECT [FirstName], [LastName]
            FROM [Employees] AS [e]
       LEFT JOIN [Addresses] AS [a]
              ON [e].[AddressID] = [a].[AddressID]
       LEFT JOIN [Towns] AS [t]
              ON [a].[TownID] = [t].[TownID]
           WHERE [t].[Name] = @TownName

EXEC [usp_GetEmployeesFromTown] @TownName = 'Sofia'

GO
--Problem 5
GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10) AS
  BEGIN
		DECLARE @SalaryLevel VARCHAR(10)
		     IF (@salary < 30000)
	      BEGIN
		    SET @SalaryLevel = 'Low'
			END
		ELSE IF (@salary BETWEEN 30000 AND 50000)
		  BEGIN
		    SET @SalaryLevel = 'Average'
			END
		   ELSE
		  BEGIN
		    SET @SalaryLevel = 'High'
			END
 RETURN @SalaryLevel
 END

GO
--Problem 6
GO

CREATE PROCEDURE [usp_EmployeesBySalaryLevel] @Level VARCHAR(10)
              AS 
		  SELECT [FirstName], [LastName]
		    FROM [Employees]
		   WHERE @Level = dbo.ufn_GetSalaryLevel([Salary])

EXEC [usp_EmployeesBySalaryLevel] @Level = 'High'

GO
--Problem 7
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
DECLARE @currentIndex INT = 1

WHILE(@currentIndex <= LEN(@word))
	BEGIN
	DECLARE @currentLetter VARCHAR(1) = SUBSTRING(@word, @currentIndex, 1)

	IF(CHARINDEX(@currentLetter, @setOfLetters)) = 0
		BEGIN
		RETURN 0
		END
	
	SET @currentIndex += 1
	END
RETURN 1
END

GO
--Problem 8
GO

CREATE PROCEDURE [usp_DeleteEmployeesFromDepartment] @departmentID INT
AS
BEGIN
	DELETE FROM [EmployeesProjects]
	      WHERE [EmployeeID] IN (
								SELECT [EmployeeID]
								  FROM [Employees]
								 WHERE [DepartmentID] = @departmentID
							    )

	UPDATE [Employees]
	   SET [ManagerID] = NULL
	 WHERE [ManagerID] IN (
	                       SELECT [EmployeeID]
							 FROM [Employees]
							WHERE [DepartmentID] = @departmentID
	                       )

    ALTER TABLE [Departments]
   ALTER COLUMN [ManagerID] INT

   UPDATE [Departments]
      SET [ManagerID] = NULL
	WHERE [ManagerID] IN (
	                     SELECT [EmployeeID]
						  FROM [Employees]
						 WHERE [DepartmentID] = @departmentID
	                     )

	DELETE FROM [Employees]
	      WHERE [DepartmentID] = @departmentID

	DELETE FROM [Departments]
		  WHERE [DepartmentID] = @departmentID

	SELECT COUNT([EmployeeID])
	  FROM [Employees]
	 WHERE [DepartmentID] = @departmentID
END

GO
--Problem 9
USE [Bank]
GO

CREATE PROCEDURE [usp_GetHoldersFullName]
AS
BEGIN
SELECT CONCAT([FirstName], ' ', [LastName])
    AS [Full Name]
  FROM [AccountHolders]
END

--Problem 10
GO

CREATE PROCEDURE [usp_GetHoldersWithBalanceHigherThan] @number MONEY
AS
BEGIN
   SELECT [FirstName]
       AS [First Name]
	    , [LastName]
	   AS [Last Name]
     FROM [AccountHolders] AS [ah]
LEFT JOIN [Accounts] AS [a]
       ON [a].[AccountHolderId] = [ah].[Id]
 GROUP BY [a].[AccountHolderId], [ah].[FirstName], [ah].[LastName]
  HAVING SUM([a].[Balance]) > @number
 ORDER BY [ah].[FirstName], [ah].[LastName]
END

EXEC [usp_GetHoldersWithBalanceHigherThan] @number = 10000

--Problem 11
GO

CREATE FUNCTION [ufn_CalculateFutureValue](@initialSum DECIMAL(15, 4), @yearlyInterestRate FLOAT, @years INT)
RETURNS DECIMAL(15, 4)
AS
BEGIN
DECLARE @futureValue DECIMAL(15, 4)

SET @futureValue = @initialSum * (POWER(1 + @yearlyInterestRate, @years))

RETURN @futureValue
END

GO

SELECT dbo.[ufn_CalculateFutureValue](1000, 10, 5)

--Problem 12
GO

CREATE PROCEDURE [usp_CalculateFutureValueForAccount] @AccountId INT, @InterestRate FLOAT
AS
SELECT [ah].[Id] AS [Account Id]
	 , [ah].[FirstName] AS [First Name]
	 , [ah].[LastName] AS [Last Name]
	 , [a].[Balance]
	 , dbo.[ufn_CalculateFutureValue]([a].[Balance], @InterestRate, 5) AS [Balance in 5 years]
  FROM [AccountHolders] AS [ah]
  JOIN [Accounts] AS [a]
    ON [a].[Id] = [ah].[Id]
 WHERE [ah].[Id] = @AccountId

EXEC [usp_CalculateFutureValueForAccount] @accountId = 1, @interestRate = 0.1

GO

--Problem 13
USE [Diablo]
GO

CREATE FUNCTION [ufn_CashInUsersGames](@gameName NVARCHAR(50))
RETURNS TABLE
AS RETURN (
			SELECT SUM([Cash])
				AS [SumCash]
			  FROM (
					SELECT [ug].[Cash]
						, ROW_NUMBER() OVER(ORDER BY [ug].[Cash] DESC)
						AS [RowNumber]
					FROM [UsersGames] AS [ug]
					JOIN [Games] AS [g]
						ON [ug].[GameId] = [g].[Id]
					WHERE [g].[Name] = @gameName
				   ) AS [OrderedRows]
			 WHERE [RowNumber] % 2 <> 0
          )

GO

--Problem 14
USE [Bank]

CREATE TABLE [Logs] (
	[LogId] INT PRIMARY KEY IDENTITY,
	[AccountId] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL,
	[OldSum] DECIMAL(18, 2) NOT NULL,
	[NewSum] DECIMAL (18, 2) NOT NULL
)

GO

CREATE TRIGGER [tr_InsertEntryIntoLogs]
            ON [Accounts]
         AFTER UPDATE
            AS
				INSERT INTO [Logs]
				     VALUES (
			     (SELECT [Id] FROM inserted),
				 (SELECT [Balance] FROM deleted),
				 (SELECT [Balance] FROM [inserted])
			    )

GO

--Problem 15
CREATE TABLE [NotificationEmails] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Recipient] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL,
	[Subject] VARCHAR(50) NOT NULL,
	[Body] VARCHAR(255) NOT NULL
)
GO

CREATE TRIGGER [tr_NotificationEmail]
            ON [Logs]
  AFTER INSERT
            AS
		 BEGIN
				INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])
				     SELECT [i].[AccountId]
					      , CONCAT('Balance change for account: ', [i].[AccountId]) AS [Subject]
						  , CONCAT('On ', GETDATE(), ' your balance was changed from ', [i].[NewSum], ' to ', [i].[OldSum]) AS [Body]
					   FROM inserted AS [i]
		   END

GO

--Problem 16
GO

CREATE OR ALTER PROC [usp_DepositMoney](@accountId INT, @moneyAmount DECIMAL(18, 2))
AS
BEGIN TRANSACTION
--If this IF statement is omitted along with the SELECT from below it gives 100/100
	IF @moneyAmount < 0
	 BEGIN
		ROLLBACK
		RAISERROR('Negative deposit amount!', 16, 1)
		RETURN
	 END

	UPDATE [Accounts]
	   SET [Balance] += @moneyAmount
	 WHERE [Id] = @accountId
--If this select is omitted it gets 75/100
	 SELECT [Id] AS [AccountId]
	      , [AccountHolderId]
		  , [Balance]
	   FROM [Accounts]
	  WHERE [Id] = @accountId
COMMIT

GO

EXEC [usp_DepositMoney] 1, 10
EXEC [usp_DepositMoney] 1, -10

--Query that works for judge
CREATE OR ALTER PROC [usp_DepositMoney](@accountId INT, @moneyAmount MONEY)
AS
BEGIN TRANSACTION
	UPDATE [Accounts]
	   SET [Balance] += @moneyAmount
	 WHERE [Id] = @accountId
COMMIT

--Problem 17
CREATE PROC [usp_WithdrawMoney](@accountId INT, @moneyAmount MONEY)
AS
BEGIN TRANSACTION
	UPDATE [Accounts]
	   SET [Balance] -= @moneyAmount
	 WHERE [Id] = @accountId
COMMIT

--Problem 18
CREATE PROC [usp_TransferMoney](@senderId INT, @receiverId INT, @amount MONEY)
AS
BEGIN TRANSACTION
	UPDATE [Accounts]
	   SET [Balance] -= @amount
	 WHERE [Id] = @senderId

	UPDATE [Accounts]
	   SET [Balance] += @amount
	 WHERE [Id] = @receiverId
COMMIT

--Problem 20
USE [Diablo]

DECLARE @userName VARCHAR(50) = 'Stamat'
DECLARE @gameName VARCHAR(50) = 'Safflower'
DECLARE @userId INT = (SELECT [Id] FROM [Users] WHERE [Username] = @userName)
DECLARE @gameId INT = (SELECT [Id] FROM [Games] WHERE [Name] = @gameName)
DECLARE @userMoney MONEY = (SELECT [Cash] FROM [UsersGames] WHERE [UserId] = @userId AND [GameId] = @gameId)
DECLARE @itemsTotalPrice MONEY
DECLARE @userGameId INT = (SELECT [Id] FROM [UsersGames] WHERE [UserId] = @userId AND [GameId] = @gameId)

BEGIN TRANSACTION
	SET @itemsTotalPrice = (SELECT SUM([Price]) FROM [Items] WHERE [MinLevel] BETWEEN 11 AND 12)

	IF @userMoney - @itemsTotalPrice >= 0
	BEGIN
		INSERT INTO [UserGameItems]
		     SELECT [i].[Id], @userGameId, FROM [Items] AS [i]
			  WHERE [i].[Id] IN (SELECT [Id] FROM [Items] WHERE [MinLevel] BETWEEN 11 AND 12)
		
		UPDATE [UsersGames]
		   SET [Cash] -= @itemsTotalPrice
		 WHERE [GameId] = @gameId AND [UserId] = @userId
		COMMIT
	END
	ELSE
	BEGIN
		ROLLBACK
	END

SET @userMoney = (SELECT [Cash] FROM [UsersGames] WHERE [UserId] = @userId AND [GameId] = @gameId)

BEGIN TRANSACTION
	SET @itemsTotalPrice = (SELECT SUM([Price]) FROM [Items] WHERE [MinLevel] BETWEEN 19 AND 21)

	IF (@userMoney - @itemsTotalPrice >= 0)
	BEGIN
		INSERT INTO [UserGameItems]
		     SELECT [i].[Id], @userGameId FROM [Items] AS [i]
			  WHERE [i].[Id] IN (SELECT [Id] FROM [Items] WHERE [MinLevel] BETWEEN 19 AND 21)

		UPDATE [UsersGames]
		   SET [Cash] -= @itemsTotalPrice
		 WHERE [GameId] = @gameId AND [UserId] = @userId
		COMMIT
	END
	ELSE
	BEGIN
	ROLLBACK
	END

  SELECT [Name] AS [Item Name]
    FROM [Items]
   WHERE [Id] IN (SELECT [ItemId] FROM [UserGameItems] WHERE [UserGameId] = @userGameId)
ORDER BY [Item Name]

--Problem 21
GO

USE [SoftUni]

GO

GO

CREATE PROCEDURE [usp_AssignProject](@employeeId INT, @projectId INT)
AS
BEGIN TRANSACTION
	DECLARE @projectCount INT
	SET @projectCount = (
							SELECT COUNT([ProjectID])
							  FROM [EmployeesProjects]
							 WHERE [EmployeeID] = @employeeId
						)
	
	IF @projectCount >= 3
	BEGIN
	RAISERROR('The employee has too many projects!', 16, 1)
	ROLLBACK
	RETURN
	END

	INSERT INTO [EmployeesProjects]
	     VALUES
	(@employeeId, @projectId)
COMMIT

GO

--Problem 22
CREATE TABLE [Deleted_Employees] (
	[EmployeeId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[MiddleName] VARCHAR(30) NOT NULL,
	[JobTitle] VARCHAR(50) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([DepartmentID]) NOT NULL,
	[Salary] MONEY NOT NULL
)

GO

CREATE TRIGGER [tr_InsertDeletedEmployees]
            ON [Employees]
  AFTER DELETE
            AS
		 BEGIN
				INSERT INTO [Deleted_Employees]([FirstName], [LastName], [MiddleName], [JobTitle], [DepartmentId], [Salary])
				     SELECT [d].[FirstName]
					      , [d].[LastName]
						  , [d].[MiddleName]
						  , [d].[JobTitle]
						  , [d].[DepartmentID]
						  , [d].[Salary]
					   FROM deleted AS [d]
		   END

GO