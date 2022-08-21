USE [SoftUni]

GO

--Problem 1
SELECT TOP(5) [EmployeeID], [JobTitle], [e].[AddressID], [a].[AddressText]
        FROM [Employees] AS [e]
   LEFT JOIN [Addresses] AS [a]
          ON [e].[AddressID] = [a].[AddressID]
    ORDER BY [e].[AddressID]

--Problem 2
SELECT TOP(50) [FirstName], [LastName], [t].Name AS [Town], [AddressText]
          FROM [Employees] AS [e]
     LEFT JOIN [Addresses] AS [a]
     	    ON [e].AddressID = [a].AddressID
     LEFT JOIN [Towns] AS [t]
     	    ON [a].TownID = [t].TownID
      ORDER BY [FirstName], [LastName]

--Problem 3
  SELECT [EmployeeID], [FirstName], [LastName], 
         [d].[Name] AS [DepartmentName]
    FROM [Employees] AS [e]
    JOIN [Departments] AS [d]
      ON [e].DepartmentID = [d].DepartmentID
   WHERE [d].[Name] = 'Sales'
ORDER BY [EmployeeID]

--Problem 4
SELECT TOP(5) [EmployeeID], [FirstName], [Salary], 
              [d].[Name] AS [DepartmentName]
         FROM [Employees] AS [e]
         JOIN [Departments] AS [d]
           ON [e].DepartmentID = [d].DepartmentID
        WHERE [Salary] > 15000
	 ORDER BY [e].[DepartmentID]

--Problem 5
SELECT TOP(3) [e].[EmployeeID], [FirstName]
         FROM [Employees] AS [e]
	FULL JOIN [EmployeesProjects] AS [ep]
		   ON [e].[EmployeeID] = [ep].[EmployeeID]
		WHERE [ep].ProjectID IS NULL
	 ORDER BY [e].[EmployeeID]

--Problem 6
  SELECT [FirstName], [LastName], [HireDate], 
         [d].[Name] AS [DeptName]
    FROM [Employees] AS [e]
    JOIN [Departments] AS [d]
      ON [e].[DepartmentID] = [d].[DepartmentID]
   WHERE YEAR([e].[HireDate]) > 1998
     AND [d].[Name] = 'Sales'
      OR [d].[Name] = 'Finance'
ORDER BY [HireDate]

--Problem 7
SELECT TOP(5) [e].[EmployeeID], [FirstName], 
              [p].[Name] AS [ProjectName]
         FROM [Employees] AS [e]
         JOIN [EmployeesProjects] AS [ep]
           ON [e].[EmployeeID] = [ep].EmployeeID
         JOIN [Projects] AS [p]
           ON [ep].ProjectID = [p].[ProjectID]
        WHERE [p].[StartDate] > '20020813'
          AND [p].EndDate IS NULL
     ORDER BY [e].[EmployeeID]

--Problem 8
SELECT [e].[EmployeeID], [FirstName],
  CASE 
	  WHEN YEAR([p].[StartDate]) > 2004 THEN NULL
	  ELSE [p].[Name]
  END AS [ProjectName]
  FROM [Employees] AS [e]
  JOIN [EmployeesProjects] AS [ep]
    ON [e].[EmployeeID] = [ep].EmployeeID
  JOIN [Projects] AS [p]
    ON [ep].ProjectID = [p].[ProjectID]
 WHERE [e].[EmployeeID] = 24

--Problem 9
    SELECT [e].[EmployeeID], [e].[FirstName], [e].[ManagerID],
		   [m].[FirstName] AS [ManagerName]
      FROM [Employees] AS [e]
INNER JOIN [Employees] AS [m]
        ON [e].[ManagerID] = [m].[EmployeeID]
	 WHERE [m].EmployeeID
	    IN (3, 7)
  ORDER BY [e].[EmployeeID]

--Problem 10
SELECT TOP(50) [e].[EmployeeID],
         CONCAT([e].[FirstName], ' ', [e].[LastName]) AS [EmlployeeName],
    	 CONCAT([m].[FirstName], ' ', [m].[LastName]) AS [ManagerName],
    	       [d].[Name] AS [DepartmentName]
          FROM [Employees] AS [e]
    INNER JOIN [Employees] AS [m]
            ON [e].[ManagerID] = [m].[EmployeeID]
    	  JOIN [Departments] AS [d]
    	    ON [e].DepartmentID = [d].DepartmentID
      ORDER BY [e].[EmployeeID]

--Problem 11
SELECT 
    MIN([a].[AverageSalary]) AS [MinAverageSalary]
  FROM
  (
	 SELECT [e].[DepartmentID],
			AVG([e].[Salary]) AS [AverageSalary]
	   FROM [Employees] AS [e]
   GROUP BY [e].[DepartmentID]
  )
   AS [a]

--Problem 12
USE [Geography]

GO

SELECT * FROM [MountainsCountries]
SELECT * FROM [Mountains]
SELECT * FROM [Peaks]
--Query for Judge
  SELECT [mc].[CountryCode], [m].[MountainRange], [p].[PeakName], [p].[Elevation]
    FROM [MountainsCountries] AS [mc]
    JOIN [Mountains] AS [m]
      ON [mc].MountainId = [m].[Id]
    JOIN [Peaks] AS [p]
      ON [m].[Id] = [p].[MountainId]
   WHERE [mc].[CountryCode] = 'BG'
     AND [p].[Elevation] > 2835
ORDER BY [p].[Elevation] DESC

--Problem 13
SELECT *
  FROM (
          SELECT [mc].[CountryCode],
                 COUNT([m].[Id]) AS [MountainRanges]
            FROM [MountainsCountries] AS [mc]
            JOIN [Mountains] AS [m]
              ON [m].[Id] = [mc].[MountainId]
        GROUP BY [mc].[CountryCode]
       ) AS [MountainRangesCountQuery]
   WHERE [CountryCode] = 'US'
      OR [CountryCode] = 'RU'
	  OR [CountryCode] = 'BG'

--Problem 14
SELECT TOP (5) [c].[CountryName], [r].[RiverName]
          FROM [Countries] AS [c]
     LEFT JOIN [CountriesRivers] as [cr]
            ON [cr].[CountryCode] = [c].[CountryCode]
     LEFT JOIN [Rivers] as [r]
            ON [r].[Id] = [cr].[RiverId]
         WHERE [c].[ContinentCode] = 'AF'
	  ORDER BY [c].[CountryName]

--Problem 15
SELECT [ContinentCode], [CurrencyCode], [CurrencyUsage]
  FROM (
        SELECT *,
               DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC) AS [Rank]
          FROM (
                   SELECT [con].[ContinentCode],
                          [coun].[CurrencyCode],
                		  COUNT([coun].[CurrencyCode]) AS [CurrencyUsage]
                     FROM [Continents] AS [con]
                LEFT JOIN [Countries] AS [coun]
                       ON [coun].[ContinentCode] = [con].[ContinentCode]
                 GROUP BY [con].[ContinentCode], [coun].[CurrencyCode]
               ) AS [CurrencyCodeCountQuery]
            WHERE [CurrencyUsage] > 1
	   ) AS [RankedCurrencyUsageQuery]
 WHERE [Rank] = 1

--Problem 16
   SELECT COUNT([CountryName]) AS [Count]
     FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
       ON [c].[CountryCode] = [mc].[CountryCode]
    WHERE [MountainId] IS NULL

--Problem 17
SELECT TOP (5) *
          FROM (
                   SELECT [c].[CountryName],
      			        MAX([p].[Elevation]) AS [HighestPeakElevation],
      					MAX([r].[Length]) AS [LongestRiverLength]
                     FROM [Countries] AS [c]
                LEFT JOIN [MountainsCountries] AS [mc]
                       ON [c].[CountryCode] = [mc].[CountryCode]
                LEFT JOIN [Mountains] AS [m]
                       ON [mc].[MountainId] = [m].[Id]
                LEFT JOIN [Peaks] AS [p]
                       ON [m].[Id] = [p].[MountainId]
                LEFT JOIN [CountriesRivers] AS [cr]
                       ON [c].[CountryCode] = [cr].[CountryCode]
                LEFT JOIN [Rivers] AS [r]
                       ON [cr].[RiverId] = [r].[Id]
      		     GROUP BY [c].[CountryName]
        	   ) AS [ElevationAndRiverQuery]
      ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [CountryName]

--Problem 18
SELECT TOP (5) [CountryName], 
          CASE
        	    WHEN [PeakName] IS NULL THEN '(no highest peak)'
        	    ELSE [PeakName]
        END AS [Highest Peak Name],
          CASE
              WHEN [PeakName] IS NULL THEN 0
        	    ELSE [Elevation]
        END AS [Highest Peak Elevation],
          CASE 
              WHEN [PeakName] IS NULL THEN '(no mountain)'
        	    ELSE [MountainRange]
        END AS [Mountain]
          FROM (
                   SELECT [c].[CountryName], [p].[PeakName], [p].[Elevation], [m].[MountainRange], [m].[Id],
                          DENSE_RANK() OVER(PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation] DESC) AS [ElevationRank]
                     FROM [Countries] AS [c]
                LEFT JOIN [MountainsCountries] AS [mc]
                       ON [c].[CountryCode] = [mc].[CountryCode]
                LEFT JOIN [Mountains] AS [m]
                       ON [mc].[MountainId] = [m].[Id]
                LEFT JOIN [Peaks] AS [p]
                       ON [m].[Id] = [p].[MountainId]
        	   ) AS [HighestPeakAndElevationQuery]
         WHERE [ElevationRank] = 1
      ORDER BY [CountryName], [Highest Peak Name]