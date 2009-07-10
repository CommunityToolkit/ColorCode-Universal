USE AdventureWorks;
GO
SELECT MIN(TaxRate)
FROM Sales.SalesTaxRate;
GO

USE AdventureWorks;
GO
SELECT MAX(TaxRate)
FROM Sales.SalesTaxRate;
GO

--Get the checksum value before the column value is changed.
USE AdventureWorks;
GO
SELECT CHECKSUM(CAST(Quantity AS int))
FROM Production.ProductInventory;
GO

UPDATE Production.ProductInventory 
SET Quantity=125
WHERE Quantity=100;
GO
--Get the checksum of the modified column.
SELECT CHECKSUM(CAST(Quantity AS int))
FROM Production.ProductInventory;

USE AdventureWorks;
GO
SELECT COUNT(DISTINCT Title)
FROM HumanResources.Employee;
GO

USE AdventureWorks;
GO
SELECT COUNT(*)
FROM HumanResources.Employee;
GO

USE AdventureWorks;
GO
SELECT COUNT(*), AVG(Bonus)
FROM Sales.SalesPerson
WHERE SalesQuota > 25000;
GO

USE AdventureWorks;
GO
SELECT COUNT_BIG(DISTINCT Title)
FROM HumanResources.Employee;
GO

USE AdventureWorks;
GO
SELECT COUNT_BIG(*)
FROM HumanResources.Employee;
GO

USE AdventureWorks;
GO
SELECT COUNT_BIG(*), AVG(Bonus)
FROM Sales.SalesPerson
WHERE SalesQuota > 25000;
GO

USE AdventureWorks;
GO
SELECT Color, SUM(ListPrice), SUM(StandardCost)
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice != 0.00 AND StyleName LIKE 'Mountain%'
GROUP BY Color
ORDER BY Color;
GO

USE AdventureWorks;
GO
SELECT Color, ListPrice, StandardCost
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice != 0.00 AND StyleName LIKE 'Mountain%'
ORDER BY Color
COMPUTE SUM(ListPrice), SUM(StandardCost) BY Color;
GO

USE AdventureWorks;
GO
SELECT Color, SUM(ListPrice), SUM(StandardCost)
FROM Production.Product
GROUP BY Color
ORDER BY Color
GO

USE AdventureWorks;
GO
SELECT SalesQuota, SUM(SalesYTD) 'TotalSalesYTD', GROUPING(SalesQuota) AS 'Grouping'
FROM Sales.SalesPerson
GROUP BY SalesQuota WITH ROLLUP;
GO

USE AdventureWorks;
GO
SELECT STDEV(Bonus)
FROM Sales.SalesPerson;
GO

USE AdventureWorks;
GO
SELECT STDEVP(Bonus)
FROM Sales.SalesPerson;
GO

USE AdventureWorks;
GO
SELECT VAR(Bonus)
FROM Sales.SalesPerson;
GO

USE AdventureWorks;
GO
SELECT VARP(Bonus)
FROM Sales.SalesPerson;
GO

SELECT TitleID, BINARY_CHECKSUM(*) 
FROM Pubs.dbo.titles GO SELECT EmployeeID, BINARY_CHECKSUM(*) 
FROM AdventureWorks.HumanResources.Employee;
GO

SELECT absolute(10)