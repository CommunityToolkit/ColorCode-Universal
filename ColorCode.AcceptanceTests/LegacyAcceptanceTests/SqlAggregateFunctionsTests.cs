using Xunit;

namespace ColorCode.SqlAcceptanceTests
{
    public class SqlAggregateFunctionsTests
    {
        public class Transform
        {
            [Fact]
            public void WillStyleAvgFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT AVG(VacationHours)as 'Average vacation hours', 
       SUM(SickLeaveHours) as 'Total sick leave hours'
FROM HumanResources.Employee
WHERE Title LIKE 'Vice President%';";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">AVG</span>(VacationHours)<span style=""color:Blue;"">as</span> <span style=""color:#A31515;"">'Average vacation hours'</span>, 
       <span style=""color:Blue;"">SUM</span>(SickLeaveHours) <span style=""color:Blue;"">as</span> <span style=""color:#A31515;"">'Total sick leave hours'</span>
<span style=""color:Blue;"">FROM</span> HumanResources.Employee
<span style=""color:Blue;"">WHERE</span> Title <span style=""color:Blue;"">LIKE</span> <span style=""color:#A31515;"">'Vice President%'</span>;
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleChecksumAggFunction()
            {
                string sourceText =
@"--Get the checksum value before the column value is changed.
USE AdventureWorks;
GO
SELECT CHECKSUM_AGG(CAST(Quantity AS int))
FROM Production.ProductInventory;
GO

UPDATE Production.ProductInventory 
SET Quantity=125
WHERE Quantity=100;
GO
--Get the checksum of the modified column.
SELECT CHECKSUM_AGG(CAST(Quantity AS int))
FROM Production.ProductInventory;";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;"">--Get the checksum value before the column value is changed.</span>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">CHECKSUM_AGG</span>(<span style=""color:Blue;"">CAST</span>(Quantity <span style=""color:Blue;"">AS</span> <span style=""color:Blue;"">int</span>))
<span style=""color:Blue;"">FROM</span> Production.ProductInventory;
GO

<span style=""color:Blue;"">UPDATE</span> Production.ProductInventory 
<span style=""color:Blue;"">SET</span> Quantity=125
<span style=""color:Blue;"">WHERE</span> Quantity=100;
GO
<span style=""color:Green;"">--Get the checksum of the modified column.</span>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">CHECKSUM_AGG</span>(<span style=""color:Blue;"">CAST</span>(Quantity <span style=""color:Blue;"">AS</span> <span style=""color:Blue;"">int</span>))
<span style=""color:Blue;"">FROM</span> Production.ProductInventory;
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleCountFunction()
            {
                string sourceText =
@"USE AdventureWorks;
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
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">COUNT</span>(<span style=""color:Blue;"">DISTINCT</span> Title)
<span style=""color:Blue;"">FROM</span> HumanResources.Employee;
GO

<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">COUNT</span>(*)
<span style=""color:Blue;"">FROM</span> HumanResources.Employee;
GO

<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">COUNT</span>(*), <span style=""color:Blue;"">AVG</span>(Bonus)
<span style=""color:Blue;"">FROM</span> Sales.SalesPerson
<span style=""color:Blue;"">WHERE</span> SalesQuota &gt; 25000;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleCountBigFunction()
            {
                string sourceText =
@"USE AdventureWorks;
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
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">COUNT_BIG</span>(<span style=""color:Blue;"">DISTINCT</span> Title)
<span style=""color:Blue;"">FROM</span> HumanResources.Employee;
GO

<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">COUNT_BIG</span>(*)
<span style=""color:Blue;"">FROM</span> HumanResources.Employee;
GO

<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">COUNT_BIG</span>(*), <span style=""color:Blue;"">AVG</span>(Bonus)
<span style=""color:Blue;"">FROM</span> Sales.SalesPerson
<span style=""color:Blue;"">WHERE</span> SalesQuota &gt; 25000;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleGroupingFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT SalesQuota, SUM(SalesYTD) 'TotalSalesYTD', GROUPING(SalesQuota) AS 'Grouping'
FROM Sales.SalesPerson
GROUP BY SalesQuota WITH ROLLUP;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> SalesQuota, <span style=""color:Blue;"">SUM</span>(SalesYTD) <span style=""color:#A31515;"">'TotalSalesYTD'</span>, <span style=""color:Blue;"">GROUPING</span>(SalesQuota) <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'Grouping'</span>
<span style=""color:Blue;"">FROM</span> Sales.SalesPerson
<span style=""color:Blue;"">GROUP</span> <span style=""color:Blue;"">BY</span> SalesQuota <span style=""color:Blue;"">WITH</span> <span style=""color:Blue;"">ROLLUP</span>;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleMaxFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT MAX(TaxRate)
FROM Sales.SalesTaxRate;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">MAX</span>(TaxRate)
<span style=""color:Blue;"">FROM</span> Sales.SalesTaxRate;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleMinFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT MIN(TaxRate)
FROM Sales.SalesTaxRate;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">MIN</span>(TaxRate)
<span style=""color:Blue;"">FROM</span> Sales.SalesTaxRate;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleSumFunction()
            {
                string sourceText =
@"USE AdventureWorks;
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
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> Color, <span style=""color:Blue;"">SUM</span>(ListPrice), <span style=""color:Blue;"">SUM</span>(StandardCost)
<span style=""color:Blue;"">FROM</span> Production.Product
<span style=""color:Blue;"">WHERE</span> Color <span style=""color:Blue;"">IS</span> <span style=""color:Blue;"">NOT</span> <span style=""color:Blue;"">NULL</span> <span style=""color:Blue;"">AND</span> ListPrice != 0.00 <span style=""color:Blue;"">AND</span> StyleName <span style=""color:Blue;"">LIKE</span> <span style=""color:#A31515;"">'Mountain%'</span>
<span style=""color:Blue;"">GROUP</span> <span style=""color:Blue;"">BY</span> Color
<span style=""color:Blue;"">ORDER</span> <span style=""color:Blue;"">BY</span> Color;
GO

<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> Color, ListPrice, StandardCost
<span style=""color:Blue;"">FROM</span> Production.Product
<span style=""color:Blue;"">WHERE</span> Color <span style=""color:Blue;"">IS</span> <span style=""color:Blue;"">NOT</span> <span style=""color:Blue;"">NULL</span> <span style=""color:Blue;"">AND</span> ListPrice != 0.00 <span style=""color:Blue;"">AND</span> StyleName <span style=""color:Blue;"">LIKE</span> <span style=""color:#A31515;"">'Mountain%'</span>
<span style=""color:Blue;"">ORDER</span> <span style=""color:Blue;"">BY</span> Color
<span style=""color:Blue;"">COMPUTE</span> <span style=""color:Blue;"">SUM</span>(ListPrice), <span style=""color:Blue;"">SUM</span>(StandardCost) <span style=""color:Blue;"">BY</span> Color;
GO

<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> Color, <span style=""color:Blue;"">SUM</span>(ListPrice), <span style=""color:Blue;"">SUM</span>(StandardCost)
<span style=""color:Blue;"">FROM</span> Production.Product
<span style=""color:Blue;"">GROUP</span> <span style=""color:Blue;"">BY</span> Color
<span style=""color:Blue;"">ORDER</span> <span style=""color:Blue;"">BY</span> Color
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleStdevFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT STDEV(Bonus)
FROM Sales.SalesPerson;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">STDEV</span>(Bonus)
<span style=""color:Blue;"">FROM</span> Sales.SalesPerson;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleStdevpFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT STDEVP(Bonus)
FROM Sales.SalesPerson;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">STDEVP</span>(Bonus)
<span style=""color:Blue;"">FROM</span> Sales.SalesPerson;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleVarFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT VAR(Bonus)
FROM Sales.SalesPerson;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> VAR(Bonus)
<span style=""color:Blue;"">FROM</span> Sales.SalesPerson;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleVarpFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT VARP(Bonus)
FROM Sales.SalesPerson;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">VARP</span>(Bonus)
<span style=""color:Blue;"">FROM</span> Sales.SalesPerson;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleAbsoluteFunction()
            {
                string sourceText =
@"SELECT absolute(10)";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">absolute</span>(10)
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleChecksumFunction()
            {
                string sourceText =
@"--Get the checksum value before the column value is changed.
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
FROM Production.ProductInventory;";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;"">--Get the checksum value before the column value is changed.</span>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">CHECKSUM</span>(<span style=""color:Blue;"">CAST</span>(Quantity <span style=""color:Blue;"">AS</span> <span style=""color:Blue;"">int</span>))
<span style=""color:Blue;"">FROM</span> Production.ProductInventory;
GO

<span style=""color:Blue;"">UPDATE</span> Production.ProductInventory 
<span style=""color:Blue;"">SET</span> Quantity=125
<span style=""color:Blue;"">WHERE</span> Quantity=100;
GO
<span style=""color:Green;"">--Get the checksum of the modified column.</span>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">CHECKSUM</span>(<span style=""color:Blue;"">CAST</span>(Quantity <span style=""color:Blue;"">AS</span> <span style=""color:Blue;"">int</span>))
<span style=""color:Blue;"">FROM</span> Production.ProductInventory;
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleBinaryChecksumFunction()
            {
                string sourceText =
@"SELECT TitleID, BINARY_CHECKSUM(*) 
FROM Pubs.dbo.titles GO SELECT EmployeeID, BINARY_CHECKSUM(*) 
FROM AdventureWorks.HumanResources.Employee;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> TitleID, <span style=""color:Blue;"">BINARY_CHECKSUM</span>(*) 
<span style=""color:Blue;"">FROM</span> Pubs.dbo.titles GO <span style=""color:Blue;"">SELECT</span> EmployeeID, <span style=""color:Blue;"">BINARY_CHECKSUM</span>(*) 
<span style=""color:Blue;"">FROM</span> AdventureWorks.HumanResources.Employee;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }
        }
    }
}