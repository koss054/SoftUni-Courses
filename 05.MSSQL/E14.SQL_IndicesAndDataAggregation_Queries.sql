--Problem 1
USE [Gringotts]

SELECT COUNT (*) 
    AS [Count]
  FROM [WizzardDeposits]

--Problem 2
SELECT MAX([MagicWandSize])
    AS [LongestMagicWand]
  FROM [WizzardDeposits]

--Problem 3
  SELECT [DepositGroup], 
         MAX([MagicWandSize]) AS [LongestMagicWand]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--Problem 4
SELECT TOP (2) [DepositGroup]
          FROM [WizzardDeposits]
      GROUP BY [DepositGroup]
      ORDER BY AVG([MagicWandSize])

--Problem 5
  SELECT [DepositGroup],
         SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--Problem 6
  SELECT [DepositGroup],
         SUM([DepositAmount]) AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

--Problem 7
SELECT *
  FROM (
           SELECT [DepositGroup],
                  SUM([DepositAmount]) AS [TotalSum]
             FROM [WizzardDeposits]
            WHERE [MagicWandCreator] = 'Ollivander family'
		 GROUP BY [DepositGroup]
   	   ) AS [GetTotalSumQuery]
   WHERE [TotalSum] < 150000
ORDER BY [TotalSum] DESC

--Problem 8
  SELECT [DepositGroup], [MagicWandCreator],
         MIN([DepositCharge]) AS [MinDepositCharge]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup]

--Problem 9
  SELECT
    CASE
         WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
  	     WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
  	     WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
  	     WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
  	     WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
  	     WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
  	     ELSE '[61+]'
  END AS [AgeGroup],
         COUNT(*) AS [WizardCount]
    FROM [WizzardDeposits]
GROUP BY 
    CASE 
	     WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
  	     WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
  	     WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
  	     WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
  	     WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
  	     WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
  	     ELSE '[61+]'
     END

--Problem 10
  SELECT 
DISTINCT SUBSTRING([FirstName], 1, 1) AS [FirstLetter]
    FROM [WizzardDeposits]
   WHERE [DepositGroup] = 'Troll Chest'
GROUP BY [FirstName]
ORDER BY [FirstLetter]

--Problem 11
  SELECT [DepositGroup], [IsDepositExpired],
         AVG([DepositInterest]) AS [AverageInterest]
    FROM [WizzardDeposits]
   WHERE [DepositStartDate] > '19850101'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]

--Problem 12
SELECT SUM([Difference])
    AS [SumDifference]
  FROM (
		SELECT [wd1].[FirstName]
			AS [Host Wizard],
			   [wd1].[DepositAmount]
			AS [Host Wizard Deposit],
			   [wd2].[FirstName]
			AS [Guest Wizard],
			   [wd2].[DepositAmount]
			AS [Guest Wizard Deposit],
			   [wd1].[DepositAmount] - [wd2].[DepositAmount]
			AS [Difference]
		  FROM [WizzardDeposits] AS [wd1]
		  JOIN [WizzardDeposits] AS [wd2]
			ON [wd1].[Id] + 1 = [wd2].[Id]
	   )    AS [DepositDifferenceSubQuery]

--Problem 13
USE [SoftUni]

  SELECT [DepartmentID],
         SUM([Salary]) AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--Problem 14
  SELECT [DepartmentID],
         MIN([Salary]) AS [MinimumSalary]
    FROM [Employees]
   WHERE [DepartmentID] = 2 OR [DepartmentID] = 5 OR [DepartmentID] = 7
     AND [HireDate] > '20000101'
GROUP BY [DepartmentID]

--Problem 15
SELECT *
  INTO [EmployeesAvgSal]
  FROM [Employees]
 WHERE [Salary] > 30000

DELETE
  FROM [EmployeesAvgSal]
 WHERE [ManagerID] = 42

UPDATE [EmployeesAvgSal]
   SET [Salary] += 5000
 WHERE [DepartmentID] = 1

  SELECT [DepartmentID],
         AVG([Salary]) AS [AverageSalary]
    FROM [EmployeesAvgSal]
GROUP BY [DepartmentID]

--Problem 16
SELECT *
  FROM (
          SELECT [DepartmentID],
                 MAX([Salary]) AS [MaxSalary]
            FROM [Employees]
        GROUP BY [DepartmentID]
       ) AS [MaxSalaryQuery]
 WHERE [MaxSalary] NOT BETWEEN 30000 AND 70000

--Problem 17
  SELECT COUNT([EmployeeID]) AS [Count]
    FROM [Employees]
   WHERE [ManagerID] IS NULL
GROUP BY [ManagerID]

--Problem 18
SELECT DISTINCT [DepartmentID],
                [Salary]
	         AS [ThirdHighestSalary]
           FROM (
				SELECT [DepartmentID],
					   [Salary],
					   DENSE_RANK() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary] DESC)
					AS [SalaryRank]
				  FROM [Employees]
                )    AS [RankedSalariesSubQuery]
          WHERE [SalaryRank] = 3


--Problem 19
  SELECT [DepartmentID],
         AVG([Salary])
  	  AS [AvgSalary]
    FROM [Employees]
	  AS [esub]
GROUP BY [DepartmentID]

SELECT TOP (10) [e].[FirstName],
                [e].[LastName],
         	    [e].[DepartmentID]
           FROM [Employees]
             AS [e]
          WHERE [e].[Salary] > (
								  SELECT AVG([Salary])
  									  AS [AvgSalary]
									FROM [Employees]
									  AS [esub]
								   WHERE [esub].[DepartmentID] = [e].[DepartmentID]
								GROUP BY [DepartmentID]
						       )
       ORDER BY [e].[DepartmentID]